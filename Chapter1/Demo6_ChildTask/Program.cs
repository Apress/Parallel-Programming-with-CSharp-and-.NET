using static System.Console;
var parent = Task.Factory.StartNew(
    () =>
    {
        WriteLine("The parent task has started.");
        var child = Task.Factory.StartNew(
            () =>
            {
                WriteLine("The child task has started.");
                // Forcing some delay
                Thread.Sleep(1000);
                WriteLine("The child task has finished.");
                //  });
            }, TaskCreationOptions.AttachedToParent);
        WriteLine("The parent task has finished now.");
    }
);
//Task.WaitAll(parent, child); // CS0103
parent.Wait();
