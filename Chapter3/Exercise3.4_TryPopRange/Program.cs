using static System.Console;
using System.Collections.Concurrent;

var stack = new ConcurrentStack<int>();
for(int i=1;i<=5;i++)
{
    stack.Push(i);
}
var items = new int[10];
//if (stack.TryPopRange(items) > 0) // 5       4       3       2       1       0       0       0       0       0
if (stack.TryPopRange(items,1, 10) > 0) // Exception because startIndex + count is greater than the length of items.
 //if (stack.TryPopRange(items, 1, 3) > 0)  // 0       5       4       3       0       0       0       0       0       0
{
    foreach (int item in items)
    {
        Write($"{item}\t");
    }
}






