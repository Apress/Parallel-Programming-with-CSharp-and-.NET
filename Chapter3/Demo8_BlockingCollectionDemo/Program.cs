using static System.Console;
using System.Collections.Concurrent;

BlockingCollection<Car> cars = new(3);
//BlockingCollection<Car> cars = new(new ConcurrentBag<Car>(), 3);

var produceAndConsumeTask=Task.Run(ExerciseProducerConsumer);
produceAndConsumeTask.Wait();
WriteLine($"At present, the repository contains {cars.Count} car(s).");


void ExerciseProducerConsumer()
{
    var producerTask = Task.Run(ProduceCars);
    // Activating the producer a little bit early
    Thread.Sleep(300);
    var consumerTask = Task.Run(ConsumeCars);
    try
    {
        Task.WaitAll(producerTask, consumerTask);   
    }
    catch (Exception ex)
    {
        WriteLine(ex.ToString());
    }   
}

void ProduceCars()
{
    Car car;
    for(int i = 0;i<10;i++)
    {
        car = new($"{i}-Hyundai Creta", "Pearl");        
        cars.Add(car);
        Thread.Sleep(200);
        WriteLine($"Produced: {car}");
    }
    // The following code prevents the consumer's foreach loop from hanging
    cars.CompleteAdding();
    WriteLine($"+++ Production completed. +++");
}
void ConsumeCars()
{
    foreach (var car in cars.GetConsumingEnumerable())
    {
        WriteLine($"\tConsumed: {car}");
        Thread.Sleep(500);
    }
    WriteLine($"--- Consumption completed. ---");
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




