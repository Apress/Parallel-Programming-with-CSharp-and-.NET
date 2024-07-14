using static System.Console;

//var helloTask = Task.Factory.StartNew(() =>
var helloTask = Task.Run(() =>
{
    WriteLine("Hello reader!");
    var aboutTask = Task.Factory.StartNew(() =>
    {
        Task.Delay(1000);
        WriteLine("How are you?");
    }, TaskCreationOptions.AttachedToParent);
});

helloTask.Wait();

//ReadKey();


