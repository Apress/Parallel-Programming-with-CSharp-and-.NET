using static System.Console;
WriteLine("Handling cancellations and exceptions.");
CancellationTokenSource cts = new();
CancellationToken token = cts.Token;

var transferMoney = Task.Run(
 () =>
 {
     WriteLine($"Initiating the money transfer.");
     int progressBar = 0;
     WriteLine("Press c to cancel within 5 sec.");
     // Assuming the task will take 5 seconds.
     // So, after every second, we'll increase the progress by 20%
     for (int i = 0; i < 5; i++)
     {
         token.ThrowIfCancellationRequested();
         Thread.Sleep(1000);
         progressBar += 20;
         WriteLine($"Progress:{progressBar}%");
     }
     return "The money transfer is completed.";
 }, token);

var input = ReadKey().KeyChar;
if (input.Equals('c'))
{
    WriteLine("\nCancellation is requested.");
    cts.Cancel();
}
try
{
    transferMoney.Wait();
    //transferMoney.Wait(token); // For cancellation, the error will be caught inside the catch block that handles OperationCanceledException
    //await transferMoney; // Same observation( as in case of using Wait(token))    
}
catch (AggregateException ae)
{
    ae.Handle(e =>
    {
        WriteLine($"Caught error:  {e.Message}");
        return true;
    });
}

catch (OperationCanceledException oce)
{
    WriteLine($"Caught error due to cancellation: {oce.Message}");
}
//catch (Exception e)
//{
//    WriteLine($"Error:{e.GetType()}, {e.Message}");
//}

if (transferMoney.Status == TaskStatus.RanToCompletion)
{
    WriteLine(transferMoney.Result);
}
// The following line is introduced to discuss the question Q2.7 in the Q&A Session
// Wait till the task finishes the execution
//while (!transferMoney.IsCompleted) { }

WriteLine($"Current status: {transferMoney.Status}");
WriteLine("Thank you, visit again!");

