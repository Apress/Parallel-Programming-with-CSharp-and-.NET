using static System.Console;

WriteLine("Q&A on exception handling.");

try
{
    var task1 = Task.Run(
     () => throw new InsufficientMemoryException($"Cannot store 500 MB data."){ Source = "task1" });
    var task2 = Task.Run(
     () => throw new InsufficientMemoryException($"Cannot store 500 MB data."){ Source = "task2" });

    Task.WaitAll(task1, task2);
}
catch (AggregateException ae)
{
    ae.Handle(e =>
    {
        WriteLine($"Caught error: {e.Message} [From {e.Source}]");
        return true;
    });
}
