using static System.Console;

WriteLine("Reviewing Exceptions.");

#region Checking normal methods
try
{
    var validateTask = Task.Run(() => InvalidClass.UnknownUserDenied("abc"));
    WriteLine(validateTask.Result);
}

//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        WriteLine($"Exception type: {e.GetType()}, Message: {e.Message}");
//    }
//}
catch (Exception e)
{
    WriteLine($"Exception type: {e.GetType()}, Message: {e.Message}");
}

#endregion

#region Checking async methods
try
{
    var validateAsyncTask = await InvalidClass.UnknownUserDeniedAsync("abc");
}

catch (Exception e)
{
    WriteLine($"Exception type: {e.GetType()}, Message: {e.Message}");
}

#endregion



class InvalidClass
{
    public static string UnknownUserDenied(string user)
    {
        throw new UnauthorizedAccessException($"{user} is unauthorized");
    }

    public static async Task<string> UnknownUserDeniedAsync(string user)
    {
        await Task.Delay(1000);
        throw new UnauthorizedAccessException($"{user} is unauthorized");
    }
}