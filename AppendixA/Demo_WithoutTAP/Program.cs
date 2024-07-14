using static System.Console;

var printTask = Task.Run(() => PrintNumbers(10));
try
{
    WriteLine($"Printed up to the number: {printTask.Result}");
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        WriteLine($"Encountered error: {ae.Message}");
    }
}

WriteLine("End of the main thread.");

// The following method is synchronous.

static int PrintNumbers(int limit)
{
    int currentNumber = 0;
    WriteLine("The printing task starts now.");

    for (int i = 0; i < limit; i++)
    {
        Write($"PrintNumbers prints {i}\n");
        currentNumber = i;
        // Simulating some delay for some other activities, if any
        Thread.Sleep(500);
    }
    //return total;
    return currentNumber;
}
