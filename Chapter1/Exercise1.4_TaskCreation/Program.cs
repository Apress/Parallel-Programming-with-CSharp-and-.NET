using static System.Console;

var calculate = Task.Run(() => GetTotal(5));
WriteLine(calculate.Result);
WriteLine("End.");

static int GetTotal(int count)
{
    int total = 0;
    for (int i = 1; i <= count; i++)
    {
        total += i * 2;
    }
    return total;
}