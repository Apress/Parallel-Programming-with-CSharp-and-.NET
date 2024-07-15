using static System.Console;

WriteLine("Examining an async initialization.");

Sample sample = new();
// Introducing some delay before calling the GetFlagValue method
//Thread.Sleep(2000);
sample.GetFlagValue();


//try
//{
//    Sample sample = new();
//    Thread.Sleep(2000);
//    sample.GetFlagValue();
//}
//catch (Exception e)
//{
//    WriteLine(e.Message);
//}

ReadKey();

class Sample
{
    private int _flag;
    public Sample()
    {
        InitializeAsync();
    }
    private async void InitializeAsync()
    {
        _flag = await Repository.GetDataAsync();
        WriteLine($"The flag is set to {_flag} now.");
        // The calling thread cannot catch the following exception which can be raised due to some logic
       // throw new InvalidOperationException("Invalid ops!");        
    }
    public void GetFlagValue()
    {
        WriteLine($"The current flag value is {_flag}.");
    }
}

// The Repository class is same. There is no change in this class.
class Repository
{
    public static async Task<int> GetDataAsync()
    {
        await Task.Delay(1000);
        return new Random().Next(1, 10);
    }
}


