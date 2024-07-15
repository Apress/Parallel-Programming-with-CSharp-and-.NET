using static System.Console;

WriteLine("The main thread starts.");

WriteLine("-------------------------------------");

#region Calling the asynchronous code (Used in  demo 1)
Task<int> getValue = GetHundredAsync();
WriteLine("The main thread continues.");
// Consuming the return value which is an int
int result1 = await getValue;
WriteLine($"The invoked task returns: {result1}");
#endregion
WriteLine("-------------------------------------");

#region Task-based asynchronous equivalent
Task<int> result = GetHundred();
WriteLine("The main thread continues.");
var remainingTask = result.ContinueWith(
    t => WriteLine($"The invoked task returns: {t.Result}")
);
remainingTask.Wait();
#endregion

WriteLine("-------------------------------------");

WriteLine("The main thread ends.");

// Asynchronous version
static async Task<int> GetHundredAsync()
{
    WriteLine("The method is arranging the number.");
    await Task.Delay(1500);
    //await Thread.Sleep(1500); // Error
    WriteLine("The method resumes.");
    return 100;
}

// Synchronous version
static Task<int> GetHundred()
{
    WriteLine("The method is arranging the number.");
    Task.Delay(1500);
    //Thread.Sleep(1500); // OK
    WriteLine("The method resumes.");
    return Task.Run(() => 100);
}


