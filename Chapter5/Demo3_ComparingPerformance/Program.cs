using System.Diagnostics;
using static System.Console;

Stopwatch sw = Stopwatch.StartNew();
var numbers = Enumerable.Range(0, 4);

var results =
    numbers
    //.AsParallel()
    .Select(x => GetResult(x + 1));

results
    .ToList()
    .ForEach(x => WriteLine(x + "\t"));


//// For Q&A 
//numbers
//.Select(x => GetResult(x + 1))
//.ToList()
//.ForEach(x => WriteLine(x + "\t"));


sw.Stop();
WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

static int GetResult(int number)
{
    int waitTimeMs = number * 1000;
    // Simulating the delay
    Thread.Sleep(waitTimeMs);
    return waitTimeMs;
}
