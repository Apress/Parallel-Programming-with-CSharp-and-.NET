using static System.Console;

WriteLine("Simple cancellation demonstration.");

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

var printTask = Task.Run
 (
  () =>
  {
      // A loop that runs 100 times
      for (int i = 0; i < 100; i++)
      {
          if (token.IsCancellationRequested)
          {
              WriteLine("Cancelling the print activity.");
              // Do some cleanups, if required
              return;
          }
          WriteLine($"{i}");
          // Imposing the sleep to make some delay
          Thread.Sleep(500);
      }
  }, token
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

//printTask.Wait();

WriteLine($"The final status of printTask is: {printTask.Status}");
WriteLine("End of the main thread.");

