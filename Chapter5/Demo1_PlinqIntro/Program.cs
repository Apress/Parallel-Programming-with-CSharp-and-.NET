using static System.Console;

WriteLine("Introduction to PLINQ.");

var numbers = Enumerable.Range(1, 27);

// The query to get the new numbers.
var newNumbers =
   numbers
    .AsParallel()
  //  .AsOrdered() // For Q&A 5.2
    .Where(x => x % 5 == 0)
    .Select(num =>
    {
        WriteLine($" Processing: {num} ID:{Task.CurrentId}");
        return num + 100;
    });

//// Added for Q&A 5.3
//var newNumbers =
//    numbers
//     .AsParallel()
//     .Where(x => x % 5 == 0)
//     .Select(num =>
//     {
//         WriteLine($" Processing: {num} ID:{Task.CurrentId}");
//         return num + 100;
//     })
//     .ToList();

WriteLine("The changed numbers are as follows:");
foreach (var number in newNumbers)
{
    Write($"{number}\t");
}



