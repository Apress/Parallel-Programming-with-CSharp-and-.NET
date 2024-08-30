using static System.Console;

var createEmp = Task.Factory.StartNew(
    () =>
    {
        Employee emp = new("Bob", 1);
        WriteLine($"Created an employee with {emp}");      
    }
    )
    .ContinueWith(
      task =>
      {
          WriteLine($"Was the previous task completed? {task.IsCompletedSuccessfully}");
          WriteLine($"Current time:{DateTime.Now}");
      // }, TaskContinuationOptions.AttachedToParent
      }
    );
createEmp.Wait();


// MSDN:https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes
// Beginning with C# 12, you can define a primary
// constructor as part of the class declaration
class Employee(string name, int id)
{
    private string _name = name;
    private int _id = id;
    public override string ToString()
    {
        return $"Name: {_name} Id: {_id}";
    }
}

