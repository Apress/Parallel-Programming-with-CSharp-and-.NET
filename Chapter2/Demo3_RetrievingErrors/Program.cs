using static System.Console;

WriteLine("Exception handling demo.");

try
{
    var validateUser = Task.Run(() => Product.CheckUser("abc"));
    validateUser.Wait();    
    WriteLine("End");
}

catch (Exception e)
{
    WriteLine($"Caught error: {e.Message}");
    // For Q&A Session
    WriteLine($"Exception name: {e.GetType().Name}");
}

//catch (AggregateException ae)
//{
//    ae.Handle(e =>
//    {
//        WriteLine($"Caught error: {e.Message}");        
//        return true;
//    });
//}

//catch (AggregateException ae)
//{
//    ae.Flatten().Handle(e =>
//    {
//        if (e is UnauthorizedAccessException)
//        //if (e is DivideByZeroException)
//        {
//            WriteLine($"Caught error: {e.Message}");
//            return true;
//        }
//        else
//            return false;
//    });

//}

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
        if (userId.StartsWith('u'))
        {
            msg = $"{userId} is a valid user";
        }
        else
        {
            throw new UnauthorizedAccessException($"'{userId}' is an invalid user.");
        }
        return msg;
    }
}








