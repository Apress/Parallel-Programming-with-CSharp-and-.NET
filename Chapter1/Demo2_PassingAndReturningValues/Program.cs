using static System.Console;

WriteLine("Passing and returning values by executing tasks.");
static string CalculateFactorial(int number)
{
    int temp = Enumerable.Range(1, number).Aggregate((x, y) => x * y);
    return $"The factorial of {number} is {temp}";
}

static int Add(int number1, int number2) => number1 + number2;

var task1 = Task.Factory.StartNew(() => CalculateFactorial(5));
var task2 = Task.Factory.StartNew(() => Add(25, 17));
//var task1 = Task.Run(() => CalculateFactorial(5));
//var task2 = Task.Run(() => Add(25, 17));

var result1 = task1.Result;
WriteLine(result1);
var result2 = task2.Result;
WriteLine($"The sum of 25 and 17 is {result2}");
WriteLine($"The main thread is completed.");








