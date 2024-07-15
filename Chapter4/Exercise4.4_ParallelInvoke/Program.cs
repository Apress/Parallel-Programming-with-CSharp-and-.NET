using static System.Console;

try
{
    Action greet = new(() =>
    {
        WriteLine($"Hello reader! Started: {Task.CurrentId}");
        Thread.Sleep(500);
        WriteLine($"Have a nice day! Finished: {Task.CurrentId}");
    }
    );

    Action printMsg = new(() =>
    {
        WriteLine($"Trying to print a message. Started: {Task.CurrentId}");
        throw new InvalidOperationException("invalid operation");     
    });

    Action sayBusy= new(() =>
    {
        WriteLine($"I'm performing a lengthy operation. Started: {Task.CurrentId}");    
        Thread.Sleep(1500);
        WriteLine($"I am free now! Finished: {Task.CurrentId}");
    });

    Parallel.Invoke(greet, printMsg,sayBusy);
}
catch(AggregateException ae)
{
    foreach(Exception e in ae.InnerExceptions)
    {
        WriteLine($"Error: {e.Message}");
    }
}
