using static System.Console;

CancellationTokenSource cts = new();
CancellationToken token = cts.Token;

#region The previous approach that you learned in Chapter 2
//var repeatedTask = Task.Run(() =>
//{
//    Parallel.For(
//        1,
//        50,
//        (i) =>
//        {
//            token.ThrowIfCancellationRequested();
//            WriteLine($"Processed: {i}");
//            Thread.Sleep(1000);
//        });

//}, token);
#endregion

#region The recommened approach
ParallelOptions parallelOptions = new()
{
    CancellationToken = token
    //,TaskScheduler= TaskScheduler.Default
};
// Same as:
//ParallelOptions parallelOptions = new();
//parallelOptions.CancellationToken = token;

var repeatedTask = Task.Run(() =>
{
    Parallel.For(
        1,
        50,
        parallelOptions,
        i =>
        {
            // token.ThrowIfCancellationRequested();
            WriteLine($"Processed: {i}  ID:{Task.CurrentId}");
            Thread.Sleep(1000);
            // A dummy logic to generate an exception randomly
            if (i > 45)
            {
                int random = new Random().Next(1, 11);
                if (random % 2 == 0)
                {
                    throw new Exception($" While processing the  number {i}, the random value was: {random}");
                }
            }
        });
});
#endregion


try
{
    // Let us allow the loop to be executed for some time
    Thread.Sleep(1000);
    WriteLine("Press c to cancel");
    var input = ReadKey().KeyChar;
    if (input.Equals('c'))
        cts.Cancel();
    repeatedTask.Wait(token);  // Outputs:  Caught error: One or more errors occurred. ( While processing the  number .., the random value was: ..)
   // repeatedTask.Wait();
   }

//catch (AggregateException ae)
//{
//    ae.Handle(e =>
//    {
//        WriteLine($"\nCaught error:  {e.Message}");
//        return true;
//    });
//}

// Or, use the following
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Caught error: {e.Message}");
    }
}

catch (OperationCanceledException oce)
{
    WriteLine($"\nCaught error due to cancellation: {oce.Message} ");
}
finally
{
    cts.Dispose();
}

WriteLine("\nThe application ends now.");


