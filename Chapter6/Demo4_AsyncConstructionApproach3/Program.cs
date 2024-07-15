using static System.Console;

WriteLine("Examining an async initialization.");

//Sample sample = new(); // Error now

// Performing async initialization and unwrapping Task<Sample> to Sample
Sample sample = await Sample.InitializeAsync();
// Sample sample = await Sample.CreateAsync();
sample.GetFlagValue();


////  The calling thread can catch the exception now
//try
//{
//    // Performing async initialization and unwrapping Task<Sample> to Sample
//    Sample sample = await Sample.InitializeAsync();
//    // Sample sample = await Sample.CreateAsync();
//    sample.GetFlagValue();
//}
//catch (Exception e)
//{
//    WriteLine(e.Message);
//}


class Sample
{
    private int _flag;
    private Sample()
    {
        // Do something here, if required
    }

    // Doing the initialization work here
    public static async Task<Sample> InitializeAsync()
    {
        Sample sample = new()
        {
            _flag = await Repository.GetDataAsync()
        };
        //// Same as:
        //Sample sample = new();
        //sample._flag = await Repository.GetDataAsync();

        WriteLine($"The flag is set to {sample._flag} now.");
        //throw new InvalidOperationException("Invalid ops!");    
        return sample;
    }

    // Alternatively, segregate the work between CreateAsync and InitializeAsync.
    // In this case, you need to update the client code accordingly.
    //private  async Task<Sample> InitializeAsync()
    //{
    //    WriteLine($"InitializeAsync will set the flag.");
    //    _flag = await Repository.GetDataAsync();
    //    WriteLine($"The flag is set to {_flag} now.");
    //    // Some other code, if any
    //    return this;
    //}
    //public static  Task<Sample> CreateAsync()
    //{
    //    Sample sample = new();
    //    return sample.InitializeAsync();
    //}

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



