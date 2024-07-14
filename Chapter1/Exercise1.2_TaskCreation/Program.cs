using static System.Console;

Task printHelloTask = new(
    () =>
    {
        //Thread.Sleep(1000); 
        WriteLine("Hello!");        
    }
);
printHelloTask.Start();
//printHelloTask.Wait();
WriteLine("End.");

