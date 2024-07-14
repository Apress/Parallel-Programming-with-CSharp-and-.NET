using static System.Console;
using System.Collections.Concurrent;

var queue = new ConcurrentQueue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

int front;
if (queue.TryPeek(out front))
    WriteLine($"{front} is at the front now.");

if (queue.TryDequeue(out front))
    WriteLine($"{front} is removed now.");

if (queue.TryPeek(out front))
    WriteLine($"{front} is at the front now.");



 