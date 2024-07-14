using static System.Console;

var countdownEvent = new CountdownEvent(3);

WriteLine("Five customers are trying to enter the mall.");
for (int i = 0; i < 5; i++)
{
    Task.Run(VisitMall);
}

WriteLine($"The gatekeeper waits for {countdownEvent.CurrentCount} customers to exit.");
countdownEvent.Wait();
WriteLine($"The gatekeeper got {countdownEvent.InitialCount} signals.");
WriteLine("A new customer can enter the mall now.");
WriteLine("Press any key to exit.");
ReadKey();

void VisitMall()
{
    int random = new Random().Next(1, 5);
    Thread.Sleep(1000);
    WriteLine($"The customer {Task.CurrentId} starts purchasing.");
    Thread.Sleep(random* 500);
    WriteLine($"-----The customer {Task.CurrentId} is exiting now.");
    countdownEvent.Signal();    
}



