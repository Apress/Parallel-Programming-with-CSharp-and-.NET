using static System.Console;
using System.Collections.Concurrent;

IProducerConsumerCollection<Car> cars = new ConcurrentQueue<Car>();

var addBlackCarModelsTask = Task.Run(AddBlackCarModels);
var addNonBlackCarModelsTask = Task.Run(AddNonBlackCarModels);
Task.WaitAll(addBlackCarModelsTask, addNonBlackCarModelsTask);

WriteLine($"A total of {cars.Count} cars are added to the repository.");

WriteLine("Removing the items now...");
var removeCarsTask = Task.Run(RemoveCarModels);
removeCarsTask.Wait();
WriteLine($"A total of {cars.Count} cars are present in the repository now.");
void AddNonBlackCarModels()
{
    Car car;
    car = new("Hyundai Creta", "Pearl");
    WriteLine($"Adding: {car}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Maruti Suzuki Alto 800", "Red");
    WriteLine($"Adding: {car}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Toyota Fortuner Avant", "Bronze");
    WriteLine($"Adding: {car}");
    cars.TryAdd(car);
    Thread.Sleep(1000);
}

void AddBlackCarModels()
{
    Car car;
    car = new("Toyota Fortuner Attitude", "Black");
    WriteLine($"Adding: {car}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Hyundai Creta Abyss", "Black");
    WriteLine($"Adding: {car}");
    cars.TryAdd(car);
    Thread.Sleep(1000);
}

void RemoveCarModels()
{
    foreach (Car car in cars)
    {
        cars.TryTake(out Car result);
        WriteLine($"Tried removing: {result}");
    }

}

// Using primary constructor
class Car(string model, string color)
{
    private string _model = model;
    private string _color = color;
    public override string ToString()
    {
        return $"[{_model}, {_color}]";
    }
}
//// Same as:
//class Car
//{
//    private string _model;
//    private string _color;
//    public Car(string model, string color)
//    {
//        _model = model;
//        _color = color;
//    }
//    public override string ToString()
//    {
//        return $"[{_model}, {_color}]";
//    }
//}




