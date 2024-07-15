using System.Diagnostics;
using static System.Console;

List<int> numbers = [.. ParallelEnumerable.Range(1, 1000)];

WriteLine($"Calculating the sum of 1 to 1000.");
#region Without using thread local variable
var stopWatch = Stopwatch.StartNew();
int total = 0;
Parallel.ForEach(
    numbers,
    (x) =>
    {
        Interlocked.Add(ref total, x);
    }
);
stopWatch.Stop();
WriteLine($"The sum is: {total}");
WriteLine($"The elapsed time is {stopWatch.ElapsedTicks} timer ticks.");
WriteLine("____________");
#endregion

WriteLine($"Fine-tuning the application now.");
#region Using thread local variable
stopWatch = Stopwatch.StartNew();
total = 0;
Parallel.ForEach(
    numbers,
    () =>0,
    (int num, ParallelLoopState state, int subTotal) =>
    {
        return num + subTotal;
    },
   subTotal =>
   {
       Interlocked.Add(ref total, subTotal);
   }
 );
stopWatch.Stop();
WriteLine($"The sum is: {total}");
WriteLine($"Now the elapsed time is {stopWatch.ElapsedTicks} timer ticks.");

#endregion