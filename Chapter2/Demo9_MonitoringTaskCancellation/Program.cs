using static System.Console;

WriteLine("Monitoring the cancellation operation.");

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

token.Register(
    () =>
    {
        WriteLine("Cancelling the print activity.[Using event subscription]");
        // Do something else, if you want
    }
  );


var printTask = Task.Run
 (
  () =>
  {
      // A loop that runs 100 times
      for (int i = 0; i < 100; i++)
      {         
          // Approach-3
          token.ThrowIfCancellationRequested();
          WriteLine($"{i}");
          // Imposing the sleep to make some delay
          Thread.Sleep(500);
      }
  }, token
);

Task.Run(
    () =>
    {
        token.WaitHandle.WaitOne();
        WriteLine("Cancelling the print activity.[Using WaitHandle]");
        // Do something else, if you want
    }
);

WriteLine("Enter c to cancel the task.");
char ch = ReadKey().KeyChar;
if (ch.Equals('c'))
{
    WriteLine("\nTask cancellation requested.");
    tokenSource.Cancel();
}
// Wait till the task finishes the execution
while (!printTask.IsCompleted) { }

WriteLine($"The final status of printTask is: {printTask.Status}");
WriteLine("End of the main thread.");



