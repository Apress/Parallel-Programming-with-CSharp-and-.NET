using static System.Console;

// WriteLine("Exercise 2.9");
var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;
var printTask = Task.Run
 (
  () =>
  {
       int i = 0;
      while (i != 10)
      {
           if (token.IsCancellationRequested)
          {
              WriteLine("Cancelling the print activity.");
              return;
          }
          // Do some work, if required.         
          Thread.Sleep(1000);
          i++;
      }
  }, token
);

Thread.Sleep(500);
WriteLine("Task cancellation initiated.");
tokenSource.Cancel();
// Wait till the task finishes the execution
while (!printTask.IsCompleted) { }
WriteLine($"The final status of printTask is: {printTask.Status}");
WriteLine("End of the main thread.");


