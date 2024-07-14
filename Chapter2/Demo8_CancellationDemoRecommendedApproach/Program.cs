using static System.Console;

WriteLine("Simple cancellation demonstration.");

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

// Another token (used for additional discussion in Approach-5 here)
var tokenSource2 = new CancellationTokenSource();
var token2 = tokenSource2.Token;

var printTask = Task.Run
 (
  () =>
  {
      // A loop that runs 100 times
      for (int i = 0; i < 100; i++)
      {
          // Approach-1
          //if (token.IsCancellationRequested)
          //{
          //    WriteLine("Cancelling the print activity.");
          //    // Do some cleanups, if required
          //    return;
          //}
          //// Approach-2
          //if (token.IsCancellationRequested)
          //{
          //    WriteLine("Cancelling the print activity.");
          //    // Do some cleanups, if required
          //    throw new OperationCanceledException(token);            
          //}
          // Approach - 3
            token.ThrowIfCancellationRequested();

          //// Approach 4
          //if (token.IsCancellationRequested)
          //{
          //    // Do some cleanups, if required
          //    token.ThrowIfCancellationRequested();
          //}

          //// Approach 5 [used to demonstrate the Faulted state]
          //if (token.IsCancellationRequested)
          //{
          //    WriteLine("Cancelling the print activity.");
          //    // Do some cleanups, if required
          //    //throw new OperationCanceledException("Raised a  cancellation request");  // Will cause Faulted state
          //    // throw new OperationCanceledException(); // Will cause Faulted state
          //     throw new OperationCanceledException(token2); // Will cause Faulted state
          //     //throw new OperationCanceledException(token); // Will cause Canceled state
          //}

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

// Wait till the task finishes the execution[ Not for production code]
while (!printTask.IsCompleted) { }

WriteLine($"The final status of printTask is: {printTask.Status}");
WriteLine("End of the main thread.");


