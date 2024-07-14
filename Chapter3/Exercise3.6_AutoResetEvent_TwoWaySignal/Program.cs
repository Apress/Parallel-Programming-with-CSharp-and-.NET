using static System.Console;

var billingEvent = new AutoResetEvent(false);
var complaintEventIfAny = new AutoResetEvent(false);

var billingTask = Task.Run(PrepareBill);

// Let the billing counter open first.
Thread.Sleep(2000);
WriteLine("The customer picks up the items and moves towards the billing counter.");

// Imposing some delay to mimic a real-world scenario        
Thread.Sleep(1000);
billingEvent.Set();
WriteLine("The management waits if there is any complaint.");
complaintEventIfAny.WaitOne();
//// Imposing some delay to mimic a real-world scenario        
//Thread.Sleep(1000);
WriteLine("The management makes the customer happy.");

billingTask.Wait();
// Exception handling is not considered in this program
void PrepareBill()
{
    WriteLine("**The billing counter is waiting to serve the customer(s).**");
    billingEvent.WaitOne();
    WriteLine("**The billing counter starts functioning...**");
    int random = new Random().Next(1, 10);
    if (random > 3)
    {
        WriteLine($"The customer complains about a bill amount of ${random}");
    }
   complaintEventIfAny.Set();
    // Imposing a small delay to mimic a real-world scenario
    Thread.Sleep(2000);
    WriteLine("**The bill is generated. **");
}


