using static System.Console;
WriteLine("Exercise 2.7");

try
{
    var task1 = Task.Run(() => throw new InvalidOperationException("invalid operation"));
    var task2 = Task.Run(() => throw new  OutOfMemoryException("insufficient  memory"));
    Task.WaitAny(task1, task2);
    WriteLine("End");
}
catch (AggregateException ae)
{
    ae.Handle(e =>
    {
        if (e is InvalidOperationException |   e is OutOfMemoryException )
        {
            WriteLine($"Caught error: {e.Message}");
            return true;
        }
        return false;
    }
    );
}
