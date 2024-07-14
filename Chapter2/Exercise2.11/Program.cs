using static System.Console;

WriteLine("Exercise 2.11");
var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;
var parent = Task.Factory.StartNew(
    () =>
    {
        var finalResult = string.Empty;
        try
        {
            if (token.IsCancellationRequested)
            {
               finalResult = "The cancellation request is raised before the start of the parent task.";
                token.ThrowIfCancellationRequested();
            }
            WriteLine("The parent task has started.");

            // Creating a nested task
            var child = Task.Factory.StartNew(
                () =>
                {
                    WriteLine("The nested task has started.");
                    for (int i = 0; i < 10; i++)
                    {
                        token.ThrowIfCancellationRequested();
                        WriteLine($"\tThe nested task prints:{i}");
                        Thread.Sleep(100);
                    }
                    return "The nested task has finished too.";
                }, token);            
            
            finalResult = "Parent task: completed. Additional info: n/a.";

            // Updating the final result with the result of the nested task
            finalResult = $"Parent task: completed.\t Additional info: {child.Result} ";

        }
        catch (AggregateException ae)
        {
            foreach (Exception e in ae.InnerExceptions)
            {
                WriteLine($"Caught error: {e.Message}");
            }
        }
        catch (OperationCanceledException oce)
        {
            WriteLine($"Error: {oce.Message}");
        }
        return finalResult;
    });

WriteLine("Enter c to cancel the nested task.");
char ch = ReadKey().KeyChar;
if (ch.Equals('c'))
{
    WriteLine("\nTask cancellation requested.");
    tokenSource.Cancel();
}

WriteLine($"Status: {parent.Result}");
WriteLine("End of the main thread.");