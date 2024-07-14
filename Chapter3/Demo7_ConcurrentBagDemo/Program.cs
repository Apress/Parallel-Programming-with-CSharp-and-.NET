using static System.Console;
using System.Collections.Concurrent;

IProducerConsumerCollection<Car> cars = new ConcurrentBag<Car>();

var addBlackCars = Task.Run(ProcessBlackCarModels);
var addNonBlackCars = Task.Run(ProcessNonBlackCarModels);
Task.WaitAll(addBlackCars, addNonBlackCars);
WriteLine($"At present, the repository contains {cars.Count} car(s).");
void ProcessNonBlackCarModels()
{
    Car car;
    car = new("Hyundai Creta", "Pearl");
    WriteLine($"Adding: {car} using task-{Task.CurrentId}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Maruti Suzuki Alto 800", "Red");
    WriteLine($"Adding: {car} using task-{Task.CurrentId}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Toyota Fortuner Avant", "Bronze");
    WriteLine($"Adding: {car} using task-{Task.CurrentId}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    WriteLine($"Task-{Task.CurrentId} will try removing one item now.");
    if (cars.Count > 0)
    {
        cars.TryTake(out Car removeCar);
        WriteLine($"Tried removing: {removeCar} using task-{Task.CurrentId}");
    }
}

void ProcessBlackCarModels()
{
    Car car;
    car = new("Toyota Fortuner Attitude", "Black");
    WriteLine($"Adding: {car} using task-{Task.CurrentId}");
    cars.TryAdd(car);
    Thread.Sleep(1000);

    car = new("Hyundai Creta Abyss", "Black");
    WriteLine($"Adding: {car} using task-{Task.CurrentId}");
    cars.TryAdd(car);

    // Putting a relatively long sleep so that the other task can finish in between.
    Thread.Sleep(5000);

    WriteLine($"Task-{Task.CurrentId} will try removing three items now.");

    for (int i = 0; i < 3; i++)
    {
        if (cars.Count > 0)
        {
            cars.TryTake(out Car removeCar);
            WriteLine($"Tried removing: {removeCar} using task-{Task.CurrentId}");
        }
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
//        return $"[{_model},{_color}]";
//    }
//}





