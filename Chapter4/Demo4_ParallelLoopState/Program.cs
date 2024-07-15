using static System.Console;

var repeatedTask = Task.Run(() =>
{
    //ParallelLoopResult result =
    Parallel.For
    (
       1,
       16,
        (int i, ParallelLoopState state) =>
        {
            if (i == 7)
            {
                WriteLine($"Processing: {i} ID:{Task.CurrentId}. About to interrupt the loop.");
                //state.Stop();
                state.Break();
            }
            Thread.Sleep(1000);
            WriteLine($"Processed: {i} ID:{Task.CurrentId}");
        }
     );    
    //WriteLine($"Loop completed? {result.IsCompleted}");
    //if(result.LowestBreakIteration!=null)
    //{
    //    WriteLine($"The lowest break iteartion: {result.LowestBreakIteration}");
    //}
    //else
    //{
    //    WriteLine("The Stop() method was called");
    //}
});

repeatedTask.Wait();

WriteLine("End");