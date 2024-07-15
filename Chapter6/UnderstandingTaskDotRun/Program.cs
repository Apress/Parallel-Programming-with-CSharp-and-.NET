using static System.Console;

WriteLine("Task.Run  versus Task.Factory.StartNew");

//var a = 42;
//WriteLine(a.GetType()); // System.Int32

//// task1 is a Task<int>
////Task<int> task1 = Task.Factory.StartNew(
//var task1 = Task.Factory.StartNew(
//() =>
//{
//    return 100;
//}
//);
//WriteLine(task1.GetType());

// Notice that task1 is a Task<int>
Task<int> task1 = Task.Factory.StartNew(
    () =>
    {
        return 100;
    }
);


//Notice that  task2 is a Task<Task<int>> [ for applying async]
Task<Task<int>> task2 = Task.Factory.StartNew(
    async () =>
    {
        return 100;
    }
);

// Notice that task3 is a Task<int>. 

Task<int> task3 = Task.Run(
    () =>
    {
        return 100;
    }
);

// Notice that task4 is also a Task<int>. You can see that there is no  change in the return type.

Task<int> task4 = Task.Run(
    async () =>
    {
        return 100;
    }
);


// Notice that task5  is a Task<int> [ for applying Unwrap]
Task<int> task5 = Task.Factory.StartNew(
    async () =>
    {
        return 100;
    }
).Unwrap();

// await is unwrapping the layer
int task6 = await Task.Run(
    () =>
    {
        return 100;
    }
);

// await is unwrapping the layer
int task7 = await Task.Run(
    async () =>
    {
        await Task.Delay(100);
        return 100;
    }
);
