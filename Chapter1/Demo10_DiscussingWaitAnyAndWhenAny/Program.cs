using static System.Console;

WriteLine("The main thread starts.");

var task1 = Task.Run(
    () =>
    {
        WriteLine("Task1 starts.");
        WriteLine("Task1 ends.");
       
    }
);

var task2 = Task.Run(
    () =>
    {
        WriteLine("Task2 starts.");
        // A small delay is introduced here( to demonstrate WaitAny and WhenAny)
        Thread.Sleep(10);
        WriteLine("Task2 ends.");     ;
    }
);
//// Approach - 6
//Task.WaitAny(task1, task2);

// Approach-7
//Task.WhenAny(task1, task2);
var task = Task.WhenAny(task1, task2);

WriteLine("The end of main.");

WriteLine($"Task1's ID: {task1.Id} Task2's ID: {task2.Id}");
WriteLine($"Completed task ID: {task.Result.Id}");


