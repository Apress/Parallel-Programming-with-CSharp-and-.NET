using static System.Console;
WriteLine("Understanding the ThreadLocal<T> class.");

var flag = new ThreadLocal<int>(() => 50);

var task1 = Task.Run(
    () =>
        {
            WriteLine($" Task1 received the value: {flag.Value}");
            flag.Value += 25;
            WriteLine($" Task1 changed the value to {flag.Value}");
        }
    );

var task2 = Task.Run(
    () =>
        {
            WriteLine($"\tTask2 received the value: {flag.Value}");
            flag.Value += 50;
            WriteLine($"\tTask2 changed the value to {flag.Value}");
        }
    );

Task.WaitAll(task1, task2);
WriteLine($"Before closing the application, the main thread contains the value: {flag.Value}");

