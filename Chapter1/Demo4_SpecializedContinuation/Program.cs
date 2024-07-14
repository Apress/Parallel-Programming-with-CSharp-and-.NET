using static System.Console;

#region Demo4
var task1 = Task.Factory.StartNew(() => WriteLine("Ordering food."));
var task2 = Task.Factory.StartNew(() => WriteLine("Inviting friends."));

//var task3 = Task.Factory.ContinueWhenAll(
//     new[] { task1, task2 },
//     tasks =>
//     {
//         WriteLine("Arranging dinner.");
//     }
//     );

// Using C#12's "Collection expression" feature
var task3 = Task.Factory.ContinueWhenAll(
     [task1, task2],
     tasks =>
     {
         WriteLine("Arranging dinner.");
     }
     );

task3.Wait();
#endregion

#region For Q&A Session

//var task1 = Task.Factory.StartNew(() => "Ordering food.");
//var task2 = Task.Factory.StartNew(() => "Inviting friends.");
//var task3 = Task.Factory.ContinueWhenAll(
//     //new Task<string>[] { task1, task2 },
//     //new[] { task1, task2 }, // Ok too
//     [task1, task2], // C#12 allows this
//     tasks =>
//     {
//         foreach (var task in tasks)
//         {
//             WriteLine(task.Result);
//         }
//         WriteLine("Arranging dinner.");
//     }
//     );
//task3.Wait();

#endregion

