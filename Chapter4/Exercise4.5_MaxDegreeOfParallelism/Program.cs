using static System.Console;

try
{
    ParallelOptions parallelOptions = new()
    {
        MaxDegreeOfParallelism = 0 // Causes ArgumentOutOfRangeException 
        //MaxDegreeOfParallelism = -1 // OK
        //MaxDegreeOfParallelism = -2 // Also causes ArgumentOutOfRangeException 
    };

    List<int> numbers = [.. ParallelEnumerable.Range(1, 10)];

    var repeatedTask = Task.Run(() =>
    {
        Parallel.ForEach(
            numbers,
           parallelOptions,
            i =>
            {
                WriteLine($"Processed the number: {i}");
            });
    });

    repeatedTask.Wait();

}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Error: {e.Message}");
    }
}
catch (ArgumentOutOfRangeException e)
{
    WriteLine($"Caught error: {e.Message}");
}


