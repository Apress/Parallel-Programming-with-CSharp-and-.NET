using System.Text;
using static System.Console;

List<int> numbers = Enumerable.Range(1, 10).ToList();
//List<int> numbers = ParallelEnumerable.Range(1, 10).ToList();
//List<int> numbers = [.. ParallelEnumerable.Range(1, 10)];

#region Conventional Loops

// Approach: 1
WriteLine("Using foreach loop.");
foreach (int i in numbers)
{
    WriteLine($"Number:{i}, Incremented number: {i + 100}");
}
WriteLine("__________");

// Approach: 2
WriteLine("Using for loop.");
for (int i = 0; i < numbers.Count; i++)
{
    WriteLine($"Number: {numbers[i]}, Incremented number: {numbers[i] + 100}");
}
WriteLine("__________");
// Approach: 3
WriteLine("Using ForEach function.");
numbers.ForEach(
    i => WriteLine($"Number: {i}, Incremented number: {i + 100}")
);
WriteLine("__________");
#endregion

#region Parallel loops
WriteLine("\nUsing Parallel ForEach");
// Approach: 4
Parallel.ForEach(
   numbers,
   i => WriteLine($"Number:{i}, Incremented number:{i + 100}, Id:{ Task.CurrentId}")
);
WriteLine("Ending Parallel ForEach");

// Approach: 5
WriteLine("\nUsing Parallel For");
Parallel
    .For(
      1,
      numbers.Count + 1,
      i => WriteLine($"Number:{i}, Incremented number:{i + 100}, Id:{ Task.CurrentId}")
    );
WriteLine("Ending Parallel For");
#endregion

