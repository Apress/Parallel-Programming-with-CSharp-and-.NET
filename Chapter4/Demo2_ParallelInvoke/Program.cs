using static System.Console;

#region Parallel.Invoke
WriteLine("Using Parallel.Invoke method.");
Action greet = new(() => WriteLine($"Task {Task.CurrentId} says: Hello reader!"));
Action printMsg = new(() => WriteLine($"Task {Task.CurrentId} says: This is a beautiful day."));
Action suggest = new(() => WriteLine($"Task {Task.CurrentId} says: Relax now."));
Parallel.Invoke(greet, printMsg, suggest);
WriteLine("End Parallel.Invoke");
#endregion

WriteLine("_________________");
// Using for the Q&A Session
Task greet2 = Task.Factory.StartNew(() => WriteLine($"Task {Task.CurrentId} says: Hello reader!"));
Task printMsg2 = Task.Factory.StartNew(() => WriteLine($"Task {Task.CurrentId} says: This is a beautiful day."));
Task suggest2 = Task.Factory.StartNew(() => WriteLine($"Task {Task.CurrentId} says: Relax now."));

Task.WaitAll(greet2, printMsg2, suggest2);



