using System.Diagnostics;
using static System.Console;

WriteLine("Examining sequential versus parallel execution.");
List<int> input = Enumerable.Range(1, 10).ToList();

ExecuteSequentialForEach(input);
ExecuteParallelForEach(input);
void ExecuteSequentialForEach(List<int> numbers)
{
    Stopwatch sw = Stopwatch.StartNew();

    foreach (int i in numbers)
    {
        // Imposing some delay to do some other work [FOR CASE STUDY-2]
        Thread.Sleep(500);
        Write($"{i * i}\t");
    }
    sw.Stop();
    WriteLine($"\nSequential execution(using foreach) time: {sw.ElapsedMilliseconds} ms\n");
}
WriteLine("______________");
void ExecuteParallelForEach(List<int> numbers)
{
    Stopwatch sw = Stopwatch.StartNew();
    Parallel.ForEach(
          numbers,
          i =>
          {
              // Imposing some delay to do some other work [FOR CASE STUDY-2]
              Thread.Sleep(500);
              Write($"{i * i}\t");
          }
        );
    sw.Stop();
    WriteLine($"\nParallel execution(using Parallel.ForEach) time:{sw.ElapsedMilliseconds} ms");
}
