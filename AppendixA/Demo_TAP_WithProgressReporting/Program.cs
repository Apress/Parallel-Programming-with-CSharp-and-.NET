using static System.Console;

WriteLine("Task-based asynchronous pattern (TAP) demonstration.");

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

var printTask = Task.Run(() => PrintNumbersAsync(10, token));
//printTask.Start(); // Will cause InvalidOperationException:

WriteLine("Enter c to cancel the task.");
var input = ReadKey();
if (input.KeyChar.Equals('c'))
{
    WriteLine("\nTask cancellation requested.");
    tokenSource.Cancel();
}

//// OR, automatically you can initiate a cancellation after 3 seconds as follows
//Task.Factory.StartNew(() =>
//{

//    Thread.Sleep(3000);
//    WriteLine("\nTask cancellation requested.");
//    tokenSource.Cancel();
//});

try
{
    WriteLine($"Printed up to the number: {printTask.Result}");
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Encountered error: {e.Message}");
    }
}

WriteLine("End of the main thread.");

static async Task<int> PrintNumbersAsync(int limit, CancellationToken token)
{
    int currentNumber = 0;
    WriteLine("The printing task starts now.");
    for (int i = 0; i < limit; i++)
    {
        token.ThrowIfCancellationRequested();
        #region Old code
        // Write($"PrintNumbersAsync prints {i}\n");
        #endregion

        #region New code to display progress
        Write($"PrintNumbersAsync prints {i}");
        Write($"\tCompleted {(i + 1) * 100 / limit}%\n");
        #endregion

        currentNumber = i;
        // Simulating some delay
        await Task.Delay(500, token);
    }
    return currentNumber;
}



