using static System.Console;

WriteLine("Exception handling demo.");

try
{
    var validateUser = Product.CheckUser("abc");
    WriteLine(validateUser); 
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
        }
        return msg;
    }
}








