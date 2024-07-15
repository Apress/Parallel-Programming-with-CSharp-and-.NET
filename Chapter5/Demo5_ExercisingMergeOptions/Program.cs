using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

List<int> numbers = Enumerable.Range(1, 25).ToList();
//List<int> numbers = ParallelEnumerable.Range(1, 25).ToList();

WriteLine("\nMaking square.");
var incrementedvalues =
    numbers
      .AsParallel()
    //.WithMergeOptions(ParallelMergeOptions.FullyBuffered)
    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
    .Select(x =>
    {
        var temp = Math.Pow(x, 2);
        Write($"[{temp}]");
        return temp;
    });

foreach (var number in incrementedvalues)
{
    Write($"{number} \t");
}

WriteLine("\n\n-------------\n");

#region Q&A session
var orderedList =
     numbers
    .AsParallel()
    .WithMergeOptions(ParallelMergeOptions.NotBuffered) // Request will be ignored
    .Select(x =>
    {
        var temp = Math.Pow(x, 2);
        Write($"[{temp}]");
        return temp;
    })
    .OrderDescending();

foreach (var number in orderedList)
{
    Write($"{number} \t");
}

#endregion

//ReadKey();
