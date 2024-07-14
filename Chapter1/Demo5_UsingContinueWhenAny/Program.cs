using static System.Console;

var task1 = Task.Factory.StartNew(
    () =>
    {
        Thread.Sleep(10);         
        WriteLine("Ordering food.");
    }
    );
var task2 = Task.Factory.StartNew(
    () =>
    {
        Thread.Sleep(100);         
        WriteLine("Inviting friends.");
    }
    );

var task3 = Task.Factory.ContinueWhenAny(
     new[] { task1, task2 },
    // [task1, task2], // C#12 onwards
     tasks =>
     {
         WriteLine("Arranging dinner.");
     }
     );

task3.Wait();
