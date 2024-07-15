using Nito.AsyncEx;
using static System.Console;

WriteLine("Examining async lazy Initialization");
Sample.GetFlagValue();
ReadKey();

class Sample
{
    private int _flag;
    private Sample(int flag)
    {
        _flag = flag;
    }
    //private static Lazy<Task<Sample>> InitializeAsync = new(
    //   async () =>
    //   {
    //       int data = await Repository.GetDataAsync();
    //       return new Sample(data);
    //   }
    // );

    private static AsyncLazy<Sample> NitoInitializeAsync = new(
        async () =>
        {
            int data = await Repository.GetDataAsync();
            return new Sample(data);
        }
    );

    //private static Lazy<Task<Sample>> AlternativeInitializeAsync = new(
    //  Task.Run(async () =>
    //  {
    //      int data = await Repository.GetDataAsync();
    //      return new Sample(data);
    //  }
    //));

    public static async void GetFlagValue()
    {
        //var sample = await InitializeAsync.Value;
        //var sample = await AlternativeInitializeAsync.Value;
        var sample = await NitoInitializeAsync;
        WriteLine($"The current flag value is {sample._flag}.");
    }
}

class Repository
{
    public static async Task<int> GetDataAsync()
    {
        await Task.Delay(1000);
        return new Random().Next(1, 10);
    }
}

