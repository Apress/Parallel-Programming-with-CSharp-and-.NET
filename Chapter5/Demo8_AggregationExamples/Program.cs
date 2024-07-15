using static System.Console;
# region Using in-built aggregation functions
int sum = Enumerable
    .Range(1, 10)
    .Sum(x => x * x);
WriteLine($"Sum of squares: {sum}");

int max = Enumerable
    .Range(1, 10)
    .Max();
WriteLine($"Maximum: {max}");

double average = Enumerable
    .Range(1, 10)
   .Average();
WriteLine($"Average: {average}");

WriteLine("---------");
#endregion
# region Custom aggregation (sequential)
//int total = Enumerable
//    .Range(1, 10)
//    .Select(x => x * x)
//    .Aggregate(0, (subTotal, nxtNumber) => subTotal + nxtNumber);
//WriteLine($"The sum of squares: {total}");

int total = Enumerable
    .Range(1, 10)
    .Select(x => x * x)
    .Aggregate(0, (subTotal, nxtNumber) =>
    {
        int temp = subTotal + nxtNumber;
        WriteLine($"{subTotal}+{nxtNumber}={temp}");
        return temp;
    });
WriteLine($"The sum of squares: {total}");

WriteLine("---------");
#endregion

#region Custom aggregation (parallel)

int parallelSum = ParallelEnumerable
    .Range(1, 10)
   // .AsParallel() //  Unnecessary here
    .Select(x => x * x)
    .Aggregate(
        // initialize subtotal/ seed value.
        0,
        // Executes this on each thread
        (subTotal, nxtNumber) =>
        {
        int temp = subTotal + nxtNumber;
        WriteLine($"subTotal={subTotal}, next number={nxtNumber},  temp ={ temp} id: [{ Task.CurrentId}]");
            return temp;
        },
        // Aggregating the subtotals from all threads
        (total, subTotal) =>
        {
            int temp2 = total + subTotal;
            WriteLine($"total={total},subTotal={subTotal},temp2={temp2}");
            return temp2;
        },
        // Processing the final result (if required) before you return
        total => total
    );
WriteLine($"The sum of squares: {parallelSum}");

#endregion