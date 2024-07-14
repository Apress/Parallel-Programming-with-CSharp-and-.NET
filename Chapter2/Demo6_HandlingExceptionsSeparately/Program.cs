using static System.Console;

WriteLine("Exception handling demo.");
try
{
    InvokeTasks();
}
catch (AggregateException ae)
{
    //foreach (var e in ae.InnerExceptions)
    //{
    //    WriteLine($"Caught error inside Main(): {e.Message}");
    //}
    // Same as:
    ae.Handle(e =>
    {
        WriteLine($"Caught error inside Main(): {e.Message}");
        return true;
    });

}

static void InvokeTasks()
{
    try
    {
        var task1 = Task.Run(() => Product.CheckUser("abc"));
        var task2 = Task.Run(() => Database.StoreData(501));
        var task3 = Task.Run(() => throw new DllNotFoundException("the dll is missing!"));
        Task.WaitAll(task1, task2, task3);
    }
    catch (AggregateException ae)
    {
        // Handling only InsufficientMemoryException, others will propagated up to the hierarchy
        ae.Handle(
           e =>
           {
               if (e is InsufficientMemoryException)
               {
                   WriteLine($"Caught error inside InvokeTasks(): {e.Message}");
                   return true;
               }
               else
               {
                   return false;
               }
           });
    }
}

class Product
{
    /// <summary>
    ///  This method throws an exception when an
    ///  userid does not start with 'u'
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException"></exception>
    public static string CheckUser(string userId)
    {
        string msg;
        if (userId.StartsWith("u"))
        {
            msg = $"{userId} is a valid user";
        }
        else
        {
            throw new UnauthorizedAccessException($"Id: {userId} is invalid.");
        }
        return msg;
    }
}
class Database
{
    /// <summary>
    /// This method throws an exception when 
    /// requested size is greater than 500MB
    /// </summary>
    /// <param name="sizeInMB"></param>
    /// <returns></returns>
    /// <exception cref="InsufficientMemoryException"></exception>
    public static string StoreData(int sizeInMB)
    {
        string allocation;
        if (sizeInMB > 500)
        {
            throw new InsufficientMemoryException($"Cannot store {sizeInMB} MB data.");
        }
        else
        {
            // Some code for allocation
            allocation = $"{sizeInMB} is allocated";
        }
        return allocation;
    }
}


