using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
WriteLine("Exception handling demo.");

try
{
    var task1 = Task.Run(() => Product.CheckUser("abc"));
    var task2 = Task.Run(() => Database.StoreData(501));
    Task.WaitAll(task1, task2);
}
catch (AggregateException ae)
{
    //// Initial approach
    //foreach (Exception e in ae.InnerExceptions)
    //{
    //    WriteLine($"Caught error: {e.Message}");
    //}

    //// Alternative approach-1
    //var exceptions = ae.Flatten().InnerExceptions;
    //foreach (Exception e in exceptions)
    //{
    //    WriteLine($"Caught error: {e.Message}");
    //}

    // Alternative approach-2
    ae.Handle(e =>
    {
        WriteLine($"Caught error: {e.Message}");
        // For Q&A
        //WriteLine($"Caught error: {e.Message} Source: {e.Source}");
        return true;
    });
}

class Product
{
    /// <summary>
    ///  This method throws an exception when the user ID does not start with 'u'
    /// </summary>
    /// <param name="userId"> The user ID</param>
    /// <returns>Confirming the valid user</returns>
    /// <exception cref="UnauthorizedAccessException"> The exception is thrown when the <paramref
    /// name="userId" is an invalid ID </exception>
    public static string CheckUser(string userId)
    {
        string msg;
        if (userId.StartsWith("u"))
        {
            msg = $"{userId} is a valid user";
        }
        else
        {
            // throw new UnauthorizedAccessException($"Id: {userId} is invalid.");
            // For Q&A
            throw new UnauthorizedAccessException($"Id: {userId} is invalid.") { Source = Task.CurrentId.ToString() };

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
    /// <param name="sizeInMB"> The requested size for allocation in MB</param>
    /// <returns> Confirming the storage</returns>
    /// <exception cref="InsufficientMemoryException"> The exception is thrown when the <paramref
    /// name="sizeInMB" is greater than 500 </exception>
    public static string StoreData(int sizeInMB)
    {
        string allocation;
        if (sizeInMB > 500)
        {
            // throw new InsufficientMemoryException($"Cannot store {sizeInMB} mb data.");
            // For Q&A
           throw new InsufficientMemoryException($"Cannot store {sizeInMB} MB data.") { Source = Task.CurrentId.ToString() };           
        }
        else
        {
            // Some code for allocation
            allocation = $"{sizeInMB} is allocated";
        }
        return allocation;
    }
}






