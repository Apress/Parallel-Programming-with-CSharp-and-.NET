using static System.Console;

var task1 = Task.Factory.StartNew(() => WriteLine("Ordering food."));
var task2 = task1.ContinueWith((t) => WriteLine("Inviting friends."));
var task3 = task2.ContinueWith((t) => WriteLine("Arranging dinner."));
task3.Wait();

