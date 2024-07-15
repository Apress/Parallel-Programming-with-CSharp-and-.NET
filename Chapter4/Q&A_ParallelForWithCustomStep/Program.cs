using static System.Console;

WriteLine("Looping with a custom step size.( Using a sequential loop)");
int step = 5;
for (int i = 0; i <= 50; i += step)
{
    Write($"{i}\t");
}

WriteLine("\n====================");

WriteLine("Looping with a custom step size.( Using a parallel loop)");
static IEnumerable<int> InputDomain(int start, int endInclusive, int stepCounter)
{
    for (int i = start; i <= endInclusive; i += stepCounter)
    {
        yield return i;
    }
}

Parallel.ForEach(
    InputDomain(0, 50, 5),
    i => Write($"{i}\t")
   );

WriteLine("\n====================");
// Another approach
Parallel.ForEach(
 Enumerable
   .Range(0, 11)
   .Select(i => i * 5), i => Write($"{i}\t")
);





