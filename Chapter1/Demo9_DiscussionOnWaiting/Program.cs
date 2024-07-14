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
        WriteLine("Task2 ends.");
    }
);
// Approach-1
//Thread.Sleep(500);
//Thread.Sleep(1000);

// Approach - 2
 Task.Delay(1000);

// For Q&A
//SpinWait.SpinUntil(() =>task1.Status == TaskStatus.RanToCompletion);


//Approach-3
//ReadKey();
//ReadLine();
//Read();

//// Approach-4
//task1.Wait();
//task2.Wait();

//// Approach-5
//Task.WaitAll(task1, task2);

WriteLine("The end of main.");



