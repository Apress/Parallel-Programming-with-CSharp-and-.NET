using static System.Console;

#region without ParallelOptions
//var repeatedTask2 = Task.Run(() =>
//{
//    Parallel.For(
//        1,
//        10,
//        i =>
//        {
//            WriteLine($"Processed:{i} with the task ID: [{Task.CurrentId}]");
//        });    
//});

//repeatedTask2.Wait();
#endregion

#region with ParallelOptions

ParallelOptions parallelOptions = new()
{
    MaxDegreeOfParallelism = 2
    //MaxDegreeOfParallelism = -1 // Also OK
    //MaxDegreeOfParallelism = -2 // ArgumentOutOfRangeException
};

var repeatedTask2 = Task.Run(() =>
{
    Parallel.For(
        1,
        10,
        parallelOptions,
        i =>
        {
            WriteLine($"Processed:{i} with the task ID: [{Task.CurrentId}]");
        });
});

repeatedTask2.Wait();
#endregion
