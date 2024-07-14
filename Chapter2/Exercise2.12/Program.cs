using static System.Console;

TaskCompletionSource<int> tcs = new();
int value = 10;

var task1=Task.Run(() => value++);

var task2=Task.Run(() =>
{
    Thread.Sleep(2000);
    tcs.SetResult(value*10);
}
);

Thread.Sleep(1000);
WriteLine($"The final result is: {tcs.Task.Result}");
