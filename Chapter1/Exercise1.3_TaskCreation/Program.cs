using static System.Console;
var saySomething = (string msg = "Hello") => msg;

var printHelloTask = Task.Factory.StartNew(
    () =>
    {
        Thread.Sleep(1000);        
        WriteLine(saySomething());
    }
);
printHelloTask.Wait();
WriteLine("End.");
