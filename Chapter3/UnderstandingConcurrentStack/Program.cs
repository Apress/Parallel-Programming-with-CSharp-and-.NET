using static System.Console;
using System.Collections.Concurrent;

var stack = new ConcurrentStack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

int top;
if (stack.TryPeek(out top))
    WriteLine($"{top} is on top now.");

if (stack.TryPop(out top))
    WriteLine($"{top} is popped now.");

if (stack.TryPeek(out top))
    WriteLine($"{top} is on top now.");

var items = new int[5];
if (stack.TryPopRange(items) > 0) // 2       1       0       0       0
//if (stack.TryPopRange(items, 1, 3) > 0)  // 0       2       1       0       0   
//if (stack.TryPopRange(items, 2, 3) > 0)  // 0       0       2       1       0
{
    foreach (int item in items)
    {
        Write($"{item}\t");
    }
}

var newElements = new int[] { 10, 11, 12 };
stack.PushRange(newElements);
ReadKey();





