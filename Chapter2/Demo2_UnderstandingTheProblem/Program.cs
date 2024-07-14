using static System.Console;

WriteLine("Exception handling demo.");

try
{
    var validateUser = Task.Run(() => Product.CheckUser("abc"));
    //var validateUser = Task.Factory.StartNew(() => Product.CheckUser("abc")); //Ok
    //var validateUser = Task<string>.Factory.StartNew(() => Product.CheckUser("abc")); // Ok too    
    WriteLine("End");
}

catch (Exception e)
{
    WriteLine($"Caught error: {e.Message}");
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
            throw new UnauthorizedAccessException($"Id: {userId} is invalid.");
            //throw new UnauthorizedAccessException($"Id: {userId} is invalid.") { Source = Task.CurrentId.ToString() };
        }
        return msg;
    }
}






