using static System.Console;

Task printHelloTask = new (
    () => WriteLine("Hello!") 
);
//printHelloTask.Start();
//printHelloTask.Wait();
WriteLine("End.");


