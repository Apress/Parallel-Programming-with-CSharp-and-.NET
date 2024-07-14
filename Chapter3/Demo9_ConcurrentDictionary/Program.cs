using static System.Console;
using System.Collections.Concurrent;

ConcurrentDictionary<int, string> cars = new();

var addBlackCarModelsTask = Task.Run(AddBlackCarModels);
var addNonBlackCarModelsTask = Task.Run(AddNonBlackCarModels);
Task.WaitAll(addBlackCarModelsTask, addNonBlackCarModelsTask);
WriteLine($"A total of {cars.Count} cars are added to the repository.");

WriteLine("\nTrying to remove one item at random now.");
int random = new Random().Next(1, 6);
var removeCarsTask = Task.Run(()=>RemoveOneCar(random));
removeCarsTask.Wait();
WriteLine($"\nA total of {cars.Count} cars are present in the repository now.");
WriteLine("\nHere is the current content of the dictionary:");
foreach (var car in cars)
{
    WriteLine($"The key: {car.Key} has the value: {car.Value}");
}

void AddNonBlackCarModels()
{
    Car car;
    car = new("Hyundai Creta","Pearl");
    WriteLine($"Adding: {car}");
    cars.TryAdd(1,car.ToString());
    Thread.Sleep(1000);

    car = new("Maruti Suzuki Alto 800", "Red");
    WriteLine($"Adding: {car}");
    cars.TryAdd(2, car.ToString());
    Thread.Sleep(1000);

    car = new("Toyota Fortuner Avant", "Bronze");
    WriteLine($"Adding: {car}");
    cars.TryAdd(3, car.ToString());
    Thread.Sleep(1000);
}

void AddBlackCarModels()
{
    Car car;
    car = new("Toyota Fortuner Attitude", "Black");
    WriteLine($"Adding: {car}");
    cars.TryAdd(4, car.ToString());
    Thread.Sleep(1000);

    car = new("Hyundai Creta Abyss", "Black");
    WriteLine($"Adding: {car}");
    cars.TryAdd(5, car.ToString());
    Thread.Sleep(1000);
}

void RemoveOneCar(int key)
{
    var isRemoved = cars.TryRemove(key, out string removedValue);
    if (isRemoved)
    {
        WriteLine($"The key {key} with value: {removedValue} is deleted.");
    }
    else
    {
        WriteLine($"Could not remove the key: {key}");
    }
}


//Using primary constructor
class Car(string model, string color)
{
    private string _model = model;
    private string _color = color;

    public override string ToString()
    {
        return $"[{_model}, {_color}]";
    }
}
