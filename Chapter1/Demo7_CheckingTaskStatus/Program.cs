using static System.Console;

var parent =  Task.Factory.StartNew(
    () =>
    {
        WriteLine($"The parent task[id:{Task.CurrentId}] has started.");
        var child = Task.Factory.StartNew(
            () =>
            {
                WriteLine($"The child task[id:{Task.CurrentId}] has started.");
                Thread.Sleep(1000);
                WriteLine("The child task has finished.");
            }, TaskCreationOptions.AttachedToParent);

        var statusChecker = child.ContinueWith(
            task =>
            {
                WriteLine($"Task id {task.Id}'s status is {task.Status}.");
            },
            TaskContinuationOptions.AttachedToParent);       
        WriteLine("The parent task has finished now.");
    }
);

parent.Wait();

