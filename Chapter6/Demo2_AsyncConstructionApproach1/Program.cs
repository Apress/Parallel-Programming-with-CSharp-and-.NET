using static System.Console;

WriteLine("Examining an async initialization.");

Sample sample = new();
// Performing async initialization and unwrapping Task<Sample> to Sample
sample = await sample.InitializeAsync();
sample.GetFlagValue();

class Sample
{
    private int _flag;
    public Sample()
    {
        // Performing sequential construction  here      
    }
    //public async void InitializeAsync()
    public async Task<Sample> InitializeAsync()
    {
        _flag = await Repository.GetDataAsync();
        WriteLine($"The flag is set to {_flag} now.");
        // Some other code, if any
        return this;
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


