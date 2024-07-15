using static System.Console;

// Use case-1
var task1 = SomeMethod();
WriteLine($"Received: {task1.Result}");

// Use case-2
var task2 = 
    SomeMethod()
    .AsTask()
    .ContinueWith
    (
       t => WriteLine($"The latest value is: {t.Result + 10}")
    );
task2.Wait();

// Use case-3
int result = await SomeMethodAsync();
WriteLine($"Got: {result}");

// Synchronous method
ValueTask<int> SomeMethod()
{
    // Some other code, if any
    return new ValueTask<int>(50);
}

// Asynchronous method
async ValueTask<int> SomeMethodAsync()
{
    await Task.Delay(100);
    //return new ValueTask<int>(100); // Error now
    return 100; // OK
}



