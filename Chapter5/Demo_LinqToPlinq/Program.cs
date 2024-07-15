using static System.Console;

const int count = 30;
var numbers = Enumerable.Range(0, count);

WriteLine("Using LINQ.");

var divisibleByFive =
    numbers
    .Where(x => x % 5 == 0);

WriteLine("Numbers divisible by 5 are:");
foreach (var x in divisibleByFive)
{
    Write($"{x}\t");
}


WriteLine("\n\nUsing PLINQ (Using AsParallel method).");

divisibleByFive =
   numbers
  .AsParallel()
  .Where(x => x % 5 == 0);

WriteLine("Numbers divisible by 5 are:");
foreach (var x in divisibleByFive)
{
    Write($"{x}\t");
}

WriteLine("\n\nUsing PLINQ (Using ParallelEnumerable class).");

numbers = ParallelEnumerable
    .Range(0, count)
    .Where(x => x % 5 == 0);

WriteLine("Numbers divisible by 5 are:");

foreach (var x in divisibleByFive)
{
    Write($"{x}\t");
}

WriteLine("\n\nUsing PLINQ (Using ParallelEnumerable class+ WithExecutionMode method).");
numbers = ParallelEnumerable
    .Range(0, count)
    .Where(x => x % 5 == 0)
    .WithExecutionMode(ParallelExecutionMode.ForceParallelism);
//.WithDegreeOfParallelism(4);

WriteLine("Numbers divisible by 5 are:");

foreach (var x in divisibleByFive)
{
    Write($"{x}\t");
}

WriteLine("\n\nUsing PLINQ (Using ParallelEnumerable class+ ForAll method).");
WriteLine("Numbers divisible by 5 are:");
ParallelEnumerable
    .Range(0, count)
    .Where(x => x % 5 == 0)
    .ForAll(num => Write($"{num}\t"));
