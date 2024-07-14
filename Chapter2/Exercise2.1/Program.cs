using static System.Console;

WriteLine("Exercise 2.1.");
try
{
    int b = 0;
    Task<int> value = Task.Run(() => 10 /b);
    //WriteLine(value.Result);
}
catch (Exception e)
{
    WriteLine($"Caught error: {e.Message}");
}
WriteLine("End");
