using static System.Console;

WriteLine("Monitoring the cancellation operation.");

var normalCancellation = new CancellationTokenSource();
var tokenNormal = normalCancellation.Token;

var unexpectedCancellation = new CancellationTokenSource();
var tokenUnexpected = unexpectedCancellation.Token;

tokenNormal.Register(
    () =>
    {
        WriteLine(" Processing a normal cancellation.");
        // Do something else, if you want
    }
  );

tokenUnexpected.Register(
    () =>
    {
        WriteLine(" Processing an unexpected cancellation.");
        // Do something else, if you want
    }
  );

var compositeToken = CancellationTokenSource.CreateLinkedTokenSource(tokenNormal, tokenUnexpected);

var printTask = Task.Run
 (
  () =>
  {
      // A loop that runs 100 times
      for (int i = 0; i < 100; i++)
      {
          compositeToken.Token.ThrowIfCancellationRequested();
          WriteLine($"{i}");
          // Imposing sleep to make some delay
          Thread.Sleep(500);
      }
  }, compositeToken.Token
);

int random = new Random().Next(1, 6);
// A dummy logic to mimic an emergency cancellation
if (random == 5)
    unexpectedCancellation.Cancel();
else
{
    WriteLine("Enter 'c' for a normal cancellation ");
    char ch = ReadKey().KeyChar;
    if (ch.Equals('c'))
    {
        WriteLine("\nTask cancellation requested.");
        normalCancellation.Cancel();
    }
}

// Wait till the task finishes the execution
while (!printTask.IsCompleted) { }

WriteLine($"The final status of printTask is: {printTask.Status}");
WriteLine("End of the main thread.");




