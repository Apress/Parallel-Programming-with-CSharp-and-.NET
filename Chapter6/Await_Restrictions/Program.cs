using static System.Console;


WriteLine("Discussing the restrictions of using the await keyword.");

#region Discussing unsafe


unsafe
{
    // Some code, if any
    //await Task.Delay(1000); // Error CS 4004

    // Some code
    // Task.Delay(1000); // OK

}

#endregion

#region  Discussing exceptions
try
{
    // do something
    throw new Exception("Forceful exception.");
}
catch (Exception e)
{
    await Task.Delay(1000);
    // Do something else
}
finally
{
    await Task.Delay(1000);
    // Do something else
}

#endregion



#region Discussing  lock
class Foo
{
    private readonly object _padLock = new();
    //public async void SomeMethod()
    //{
    //    lock (_padLock)
    //    {
    //        // Do  the synchronous operations, if any
    //        // Trying to do an asynchronous operation now
    //        //await Task.Delay(1000); //CS 1996        
    //    }
    //}
    public async void SomeMethod()
    {
        lock (_padLock)
        {
            // Do  the synchronous operations
            // and prepare for the asynchronous operation
        }

        // Doing the asynchronous operation now
        await Task.Delay(1000);
        // Lock again, if required
        lock (_padLock)
        {
            // Do  the remaining synchronous operations
        }
    }
}

#endregion

#region Discussing about the placement of await
class Sample
{
    public void SomeMethod()
    {
        // Some code, if any
        //Task.Delay(1000);// OK
        //await Task.Delay(1000); //Error CS4033
        // Some other code, if any
    }
}
#endregion