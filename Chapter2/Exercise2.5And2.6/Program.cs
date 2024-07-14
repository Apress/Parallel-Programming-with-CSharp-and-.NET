using static System.Console;
WriteLine("Exercise 2.5 and Exercise 2.6");

try
{
    DoSomething();
}
catch (AggregateException ae)
{
    ae.Handle(
        e =>
        {
            WriteLine($"Caught inside main: {e.Message}");
            return true;
        }
    );
}
static void DoSomething()
{
    try
    {
        var task1 = Task.Run(() => throw new InvalidDataException("invalid data"));
        var task2 = Task.Run(() => throw new OutOfMemoryException("insufficient memory"));
        //// For Exercise 2.5
        //Task.WaitAll(task1, task2);
        // For Exercise 2.6
        task1.Wait();
        task2.Wait();
    }
    catch (AggregateException ae)
    {
        ae.Handle(
            e =>
            {
                if (e is InvalidDataException)
                {
                    WriteLine($"Caught inside DoSomething: {e.Message}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        );
    }
}

