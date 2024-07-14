using static System.Console;
WriteLine("Exercise 2.4");

try
{
    var task1 = Task.Run( () => throw new InvalidDataException("invalid data"));
    var task2 = Task.Run(() => throw new OutOfMemoryException("insufficient  memory"));
    task1.Wait();
    task2.Wait();
    WriteLine("End");
}
catch (AggregateException ae)
{
    ae.Handle(e =>
        {
            if (e is InvalidDataException | e is OutOfMemoryException )
            {
                WriteLine($"Caught error: {e.Message}");
                return true;
            }
            return false;
        }
    );
}