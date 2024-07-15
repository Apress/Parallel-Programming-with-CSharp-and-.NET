using System.Diagnostics;
using static System.Console;

#region The code segment taken from demonstration 2
var numbers = Enumerable.Range(0, 31);

Stopwatch sw;
sw = Stopwatch.StartNew();
WriteLine("Numbers divisible by 5 are (using foreach loop):");
foreach (int num in numbers)
{
    if (num % 5 == 0)
    {
        Write($"{num}\t");
    }
}
sw.Stop();
WriteLine($"Time taken:{sw.ElapsedMilliseconds} ms");

sw = Stopwatch.StartNew();

WriteLine("\nNumbers divisible by 5 are (using LINQ and the ForEach function):");
numbers
    .Where(num => num % 5 == 0)
    .ToList()
    .ForEach(num => Write($"{num}\t"));

sw.Stop();
WriteLine($"Time taken:{sw.ElapsedMilliseconds} ms");

sw = Stopwatch.StartNew();

WriteLine("\nNumbers divisible by 5 are (using PLINQ and the ForAll function):");
numbers
    .AsParallel()
    .Where(num => num % 5 == 0)
  //   .ToList()
  //    .ForEach(num => Write($"{num}\t"));
  .ForAll(num => Write($"{num}\t"));

sw.Stop();
WriteLine($"Time taken:{sw.ElapsedMilliseconds} ms");
#endregion

sw = Stopwatch.StartNew();
WriteLine("\nNumbers divisible by 5 are(using PLINQ(dop-4):");
numbers
    .AsParallel()
    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
    .WithDegreeOfParallelism(4)
    .Where(num => num % 5 == 0)
    .ForAll(num => Write($"{num}\t"));
sw.Stop();
WriteLine($"Time taken:{sw.ElapsedMilliseconds} ms");



