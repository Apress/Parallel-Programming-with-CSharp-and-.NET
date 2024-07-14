using static System.Console;

// For Exercise 3.2
var resetEvent = new AutoResetEvent(true);

//// For Exercise 3.3
//var resetEvent = new AutoResetEvent(false);
////Invoking the set method twice in advance
//resetEvent.Set();
//resetEvent.Set();

WriteLine("Two customers are approaching the mall.");
Task.Run(VisitMall);
Task.Run(VisitMall);

// Imposing some delay to mimic a real-world scenario        
Thread.Sleep(2000);

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
