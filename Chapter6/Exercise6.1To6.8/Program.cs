using static System.Console;

#region Exercise 6.1
var task1 = Task.Run(
    async () =>
    {
        await Task.Delay(1000);
        return "Hello";
    });
WriteLine(task1.Result);
#endregion

#region Exercise 6.2
//var task2 = Task.Factory.StartNew(
//    async () =>
//    {
//        await Task.Delay(1000);
//        return "Hello";
//    });
//WriteLine(task2.Result);

var task2 = Task.Factory.StartNew(
    async () =>
    {
        await Task.Delay(1000);
        return "Hello";
    }).Unwrap();
WriteLine(task2.Result);

//var task2 = await Task.Factory.StartNew(
//    async () =>
//    {
//        await Task.Delay(1000);
//        return "Hello";
//    });
//WriteLine(task2.Result);
#endregion

#region Exercise 6.3

var task3A = new ValueTask<int>(10);

//var task3B = task3A.ContinueWith(  //Error
var task3B = task3A.AsTask().ContinueWith(  //OK
   (t) =>
   {
       int temp = task3A.Result;
       return ++temp;
       //WriteLine($"The final result is: {++temp}");
   }
);
WriteLine($"The final result is: {task3B.Result}");

#endregion

#region Exercise 6.4

string result = await GetWeatherReportAsync();
WriteLine(result);

// Asynchronous method
async ValueTask<string> GetWeatherReportAsync()
{
    await Task.Delay(100);
    return "This is a beautiful day!"; // OK
}

#endregion

#region Exercise 6.5
var number= await GetNumberAsync().AsTask();
WriteLine($"Got the number: {number}");
// Asynchronous method
async ValueTask<int> GetNumberAsync()
{
    await Task.Delay(100);
    //return new ValueTask<int>(50); // Error CS4016
    return 50; // OK
}

#endregion

#region Exercise 6.6
var task6 = Task.Run(
    async () =>
    {
        await Task.Delay(1000);
        // return 10;//OK
        return new ValueTask<int>(10); // OK too        
    });
WriteLine($"Task 6 returns: {task6.GetAwaiter().GetResult()}");
#endregion

#region Exercise 6.7
var task7 = Task.Run(
    async () =>
    {
        await Task.Delay(1000);
        return new ValueTask<int>(20).AsTask(); 
    });
WriteLine($"Task 7 returns: {await task7.GetAwaiter().GetResult()}");
#endregion


#region Exercise 6.8
var task8 = 
    Task.Factory.StartNew(
    async () =>
    {
        await Task.Delay(1000);
        return Task.Run(()=>"Hello");
    });
WriteLine($"Task 8 returns: {await await task8.Result}");
#endregion

