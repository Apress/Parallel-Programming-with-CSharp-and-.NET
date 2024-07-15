using System.Diagnostics;
using static System.Console;

int n = 10;
object lockObject = new();
//WriteLine($"Calculating the factorial of a number.");

#region Without using thread local variable
var stopWatch1 = Stopwatch.StartNew();
int factorial = 1;
Parallel.For(
    1,
    n + 1,
    (x) =>
    {
        lock (lockObject)
        {
            factorial *= x;
        }
    }
);
stopWatch1.Stop();
WriteLine($"The factorial of {n} is {factorial}");
WriteLine($"The elapsed time (Ticks): {stopWatch1.ElapsedTicks}");
#endregion

WriteLine("____________");

#region Using thread local variable now
var stopWatch2 = Stopwatch.StartNew();
int factorial2 = 1;


Parallel.For(
    1,
    n + 1,
    () => 1,
  
    (int num, ParallelLoopState state, int subFact) =>
    {
        return num * subFact;
    },
   subFact =>
   {
       lock (lockObject)
       {
           factorial2 *= subFact;
       }
   }
 );
stopWatch2.Stop();
WriteLine($"Using thread-local data, the factorial of {n} is {factorial2}");
WriteLine($"After fine-tuning, the elapsed time is {stopWatch2.ElapsedTicks} timer ticks.");
#endregion

WriteLine("____________");

#region Using PLINQ

var stopWatch3 = Stopwatch.StartNew();
factorial = ParallelEnumerable
    .Range(1, 10)
    .AsParallel()
    .Aggregate(1, (subFact, nxtNumber) => subFact * nxtNumber);
stopWatch3.Stop();
WriteLine($"Using PLINQ, the factorial of {n} is {factorial}");
WriteLine($"Now the elapsed time is {stopWatch3.ElapsedTicks} timer ticks.");

#endregion