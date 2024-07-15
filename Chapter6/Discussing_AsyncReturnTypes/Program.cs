using static System.Console;

WriteLine("The main thread starts executing.");
Task getTask = SomeTaskAsync();
WriteLine("The main thread resumes.");
await getTask;

//SomeTask2Async();
//WriteLine("The main thread resumes again.");

static async Task SomeTaskAsync()
{
    WriteLine("SomeTaskAsync is called.");
    await Task.Delay(1000);
    WriteLine("SomeTaskAsync is completed now.");
    // The following return statement  is optional
    //return; 
}

//static async void SomeTask2Async()
//{
//    WriteLine("SomeTask2Async is called.");
//    await Task.Delay(1000);
//    WriteLine("SomeTaskAsync is completed now.");
//    // The following return satement  is optional
//   // return; 
//}

