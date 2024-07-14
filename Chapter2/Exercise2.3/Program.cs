using static System.Console;
WriteLine("Exercise 2.3");

try
{
    var task1 = Task.Run(() => throw new InvalidDataException("invalid data"));
    var task2 = Task.Factory.StartNew(() => throw new OutOfMemoryException("insufficient memory"));
    Task.WaitAll(task1, task2);
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Caught error: {e.Message}");
    }
}

