using static System.Console;

WriteLine("The main thread starts executing.");


// Approach-1 

Task task1 = new(
    () =>
    {
        WriteLine("Task-1 starts.");
        for (int i = 100; i < 105; i++)
        {
            Write($"Task-1 prints {i}\t");
            // Simulating some delay for the work to be completed
            Thread.Sleep(1);
        }
        WriteLine("Task-1 is completed.");
    }
);
// Starting the task
task1.Start();

// Approach-2

Task task2 = Task.Run(
    () =>
    {
        WriteLine("Task-2 starts.");
        for (int i = 210; i < 215; i++)
        {
            Write($"Task-2 prints {i}\t");
            // Simulating some delay for the work to be completed
            Thread.Sleep(1);
        }
        WriteLine("Task-2 is completed.");
    }
);


// Approach-3

Task task3 = Task.Factory.StartNew(
    () =>
    {
        WriteLine("Task-3 starts.");
        for (int i = 320; i < 325; i++)
        {
            Write($"Task-3 prints {i}\t");
            // Simulating some delay for the work to be completed
            Thread.Sleep(1);
        }
        WriteLine("Task-3 is completed.");
    }
);

WriteLine($"The main thread is doing some other work...");
Thread.Sleep(10);

WriteLine($"Main thread is completed.");
task1.Wait();
task2.Wait();
task3.Wait();
