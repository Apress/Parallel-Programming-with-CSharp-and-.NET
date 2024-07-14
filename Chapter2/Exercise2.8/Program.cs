using static System.Console;
WriteLine("Exercise 2.8");

try
{
    var someTask = Task.Run(() => throw new InvalidOperationException("invalid operation") { Source = "Task1"});

    // Allowing some time so that the task can get up and running( Program can stuck here)
    while (someTask.Status != TaskStatus.Running)
    {
        Thread.Sleep(10);
    }

    // Waiting for the state change now
    while (someTask.Status == TaskStatus.Running)
    {
        Thread.Sleep(10);
    }
    //while (!someTask.IsCompleted) { }

    WriteLine($"SomeTask's status: {someTask.Status}");
    WriteLine("The application ends here.");
}
catch (AggregateException ae)
{
    ae.Handle(e =>
    {
        if (e is InvalidOperationException )
        {
            WriteLine($"Caught error: {e.Message} Source={e.Source}");
            return true;
        }
        return false;
    }
    );
}