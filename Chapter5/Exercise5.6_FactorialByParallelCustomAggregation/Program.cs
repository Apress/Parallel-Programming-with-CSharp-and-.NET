using static System.Console;
int n = 10;
int factorial = ParallelEnumerable
    .Range(1, n)
    .Aggregate(
        // initialize subtotal/ seed value.
        1,
        // Executes this on each thread
        (partialResult, nxtNumber) =>
        {
            int temp = partialResult * nxtNumber;
            WriteLine($"The partial value: {partialResult}, next number: {nxtNumber}, temp: {temp} id: [{Task.CurrentId}]");
            return temp;
        },
        // Aggregating the subtotals from all threads
        (finalResult, individualResult) =>
        {
            int temp2 = finalResult * individualResult;
            WriteLine($"The final result: {finalResult}, individual result: {individualResult}, temp2: {temp2}");
            return temp2;
        },
        // Processing the final result
        total => total
    );
WriteLine($"The factorial of {n} is {factorial}");
