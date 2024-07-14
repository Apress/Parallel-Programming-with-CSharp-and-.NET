using static System.Console;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

var parent =
    Task.Factory.StartNew(
    () =>
    {
        WriteLine("The parent task has started.");
        var child = Task.Factory.StartNew(
            () =>
            {
                WriteLine($"The child task[id:{Task.CurrentId}] has started.");
                Thread.Sleep(5000);
                token.ThrowIfCancellationRequested();
                WriteLine("The child task has finished.");
            }, token, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);

        var successHandler = child.ContinueWith(
            task =>
            {
                WriteLine($"Task id: {task.Id} finished successfully.");
            },
            TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

        var cancelHandler = child.ContinueWith(
           task =>
           {
               WriteLine($"Task id: {task.Id} was canceled.");
           },
           TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnCanceled);

           WriteLine("The parent task has finished now.");
    }
);

WriteLine("Press 'c' immediately to cancel the child task.");
char ch = ReadKey().KeyChar;
if (ch == 'c')
{
    WriteLine("\nTask cancellation requested.");
    tokenSource.Cancel();
}
parent.Wait();



