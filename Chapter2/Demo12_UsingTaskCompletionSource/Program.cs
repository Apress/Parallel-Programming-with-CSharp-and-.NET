using static System.Console;

TaskCompletionSource<Job> taskCompletionSource = new();
Task<Job> collectInfoTask = taskCompletionSource.Task;

WriteLine($"Starts processing a job.");
Job job = new(1)
{
    Executor = "Roy"
};

// Do something else if required       

#region Errorneous code block

//job.JobNumber = 2; //Error, if you use init accessor
//job.Executor = "John";

// Starting a background task that will complete  taskCompletionSource.Task
//var backgroundTask = Task.Run(
//    () =>
//    {
//        WriteLine(" Monitoring the activity before setting the result.");
//        // Imposing some forced delay before setting the result to mimic real-world
//        Thread.Sleep(3000);
//        taskCompletionSource.SetResult(job);
//        // The following line will cause an exception now
//        taskCompletionSource.SetResult(job);
//        //bool setResultStatus = taskCompletionSource.TrySetResult(job);
//        //WriteLine($" The setResultStatus is: {setResultStatus}"); // True    
//    });

//// Imposing a forced delay so that the background task can start running
//// before executing rest of the code
//Thread.Sleep(1000);
//backgroundTask.Wait();
#endregion

#region  The code block that is used in the demonstration 12
// Starting a background task that will complete  taskCompletionSource.Task
var backgroundTask = Task.Run(
    () =>
    {
        WriteLine(" Monitoring the activity before setting the result.");
        // Imposing some forced delay before setting the result to mimic real-world
        Thread.Sleep(3000);
        bool setResultStatus = taskCompletionSource.TrySetResult(job);         
    });

// Imposing a forced delay so that the background task can start running
// before executing rest of the code
Thread.Sleep(1000);
#endregion

WriteLine("Press 'y' to get the details.");
var input = ReadKey();
if (input.KeyChar == 'y')
{
    WriteLine(collectInfoTask.Result);
    // Same as:
   // WriteLine(taskCompletionSource.Task.Result);
}

WriteLine("\nThank you!");
internal class Job
{
    public int JobNumber { get; init; }
    public string Executor { get; set; }
    public Job(int jobNumber, string executor = "Anonymous")
    {
        JobNumber = jobNumber;
        Executor = executor;
    }
    public override string ToString() =>
     $"\n{Executor} executed the job number {JobNumber}";
}

