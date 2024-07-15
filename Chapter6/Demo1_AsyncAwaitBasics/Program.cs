using static System.Console;

WriteLine("The main thread starts.");

#region Calling the synchronus code
//int result2 = GetHundred();
//WriteLine($"The invoked task returns: {result2}");
//WriteLine("---------");
#endregion

#region Calling the asynchronus code (Sample-1)
//int result = await GetHundredAsync();
//WriteLine($"The invoked task returns: {result}");
//WriteLine("---------");
#endregion

#region Calling the asynchronus code (Sample-2; it is used in the demo)
Task<int> getValue = GetHundredAsync();
WriteLine("The main thread continues.");
// Consuming the return value which is an int
int result = await getValue;
WriteLine($"The invoked task returns: {result}");
#endregion

WriteLine("The main thread ends.");

// Asynchronous version
static async Task<int> GetHundredAsync()
{
    WriteLine("The method is arranging the number.");
    await Task.Delay(1500);
    WriteLine("The method resumes.");
    return 100;
}

// Synchronous version
//static int GetHundred()
//{
//    WriteLine("The method is arranging the number.");
//    Task.Delay(1500);
//    WriteLine("The method resumes.");
//    return 100;
//}


