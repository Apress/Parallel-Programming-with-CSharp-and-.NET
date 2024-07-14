using static System.Console;

var resetEvent = new ManualResetEvent(false);

WriteLine("Two customers are approaching the mall.");
Task.Run(VisitMall);
Task.Run(VisitMall);

// Imposing some delay to mimic a real-world scenario        
Thread.Sleep(2000);

WriteLine("Press any key to issue the signal from the main thread.");
ReadKey();
resetEvent.Set();
Thread.Sleep(1000);

// Reset will restrict the new task to continue
WriteLine("Resetting the signal now.");
resetEvent.Reset();

WriteLine("Another customer is approaching the mall.");
Task.Run(VisitMall);

WriteLine("Press any key to exit.");
ReadKey();

void VisitMall()
{
    // Imposing a small delay to mimic a real-world scenario
    Thread.Sleep(1000);
    WriteLine($"The customer {Task.CurrentId} is waiting for the entry pass.");
    resetEvent.WaitOne();
    WriteLine($"The customer {Task.CurrentId} enters the mall.");
}

