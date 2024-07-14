using static System.Console;
WriteLine("Exercise 2.2");
try
{
    int b = 0;
    Task<int> value = Task.Run(() => 10 / b);
    WriteLine(value.Result);
}
catch (Exception e)
{
    WriteLine($"Encountered with {e.GetType()}");    
}
WriteLine("End");
