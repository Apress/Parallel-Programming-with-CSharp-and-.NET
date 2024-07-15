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

#region The recommended approach
ParallelOptions parallelOptions = new()
{
    CancellationToken = token
};
////Same as:
//ParallelOptions parallelOptions = new();
//parallelOptions.CancellationToken = token;

var repeatedTask = Task.Run(() =>
{
    Parallel.For
    (
        1,
        50,
        parallelOptions,
        i =>
        {
            //token.ThrowIfCancellationRequested();
            WriteLine($"Processed: {i}  ID:{Task.CurrentId}");
            Thread.Sleep(1000);
        }
     );
});
#endregion


try
{
    // Let us allow the loop to be executed for some time
    // Thread.Sleep(1000);
    WriteLine("Press c to cancel");
    var input = ReadKey().KeyChar;
    if (input.Equals('c'))
        cts.Cancel();
    // repeatedTask.Wait(); // Outputs( for  the alternative Approach):  Caught error:  The operation was canceled.
    repeatedTask.Wait(token);  // Outputs:  Caught error due to cancellation:   .....
}
catch (OperationCanceledException oce)
{
    WriteLine($"\nCaught error due to cancellation: {oce.Message} ");
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Caught error: {e.Message}");
    }
}

finally
{
    cts.Dispose();
}

WriteLine("The application ends now.");

