using static System.Console;

var numbers = Enumerable.Range(0, 100);
CancellationTokenSource cts = new();
CancellationToken token = cts.Token;

var cancellationTask = Task.Run(() =>
{
    // We'll trigger a cancellation request shortly
    Thread.Sleep(300);
    cts.Cancel();
});

var anotherTask = Task.Run(SomeMethod, token);
anotherTask.Wait();
//try
//{
//    anotherTask.Wait();
//}
//catch (AggregateException ae)
//    {
//        foreach (Exception e in ae.InnerExceptions)
//        {
//            WriteLine($"Error Type: {e.GetType().Name}, Message: {e.Message}");
//        }
//    }

WriteLine("End of the main thread.");

void SomeMethod()
{
    try
    {
         numbers
          .AsParallel()
         .Where(x => x % 10 == 0)
         .WithCancellation(token)
         .Select(
             x =>
             {
                 token.ThrowIfCancellationRequested();
                 // Imposing the delay so that the cancellation request can come in between
                 Thread.Sleep(100);
                  return x;
             }
         )
          .ForAll(num=>WriteLine($"The processed number is: {num}"));
    }
    catch (AggregateException ae)
    {
        foreach (Exception e in ae.InnerExceptions)
        {
            WriteLine($"Error Type: {e.GetType().Name}, Message: {e.Message}");
        }
    }
    catch (OperationCanceledException oce)
    {
        WriteLine($"Error: {oce.Message}");
    }
}