using static System.Console;
WriteLine("Demo: Passing a value into a task");

// Approach-1:
var task1 = new Task(() => PrintNumbers(10));
task1.Start();

// Approach-2:
var task2 = Task.Factory.StartNew(() => PrintNumbers(10));

// Approach-3:
var task3 = Task.Run(() => PrintNumbers(10));

// Approach-4:
var task4 = new Task(PrintNumbersVersion2, 10);
task4.Start();

// Approach-5:
var task5 = Task.Factory.StartNew(PrintNumbersVersion2,10);


static void PrintNumbers(int limit)
{
    for (int i = 0; i < limit; i++)
    {
        Write($"PrintNumbers prints {i}\n");
        // Doing remaining things, if any
        Thread.Sleep(1);
    }    
}

static void PrintNumbersVersion2(object? state)
{
    int limit = Convert.ToInt32(state);
    for (int i = 0; i < limit; i++)
    {
        Write($"PrintNumbers prints {i}\n");
        // Doing remaining things, if any
        Thread.Sleep(1);
    }
}

WriteLine($"Main thread is completed.");
task1.Wait();
task2.Wait();
task3.Wait();
task4.Wait();
task5.Wait();
