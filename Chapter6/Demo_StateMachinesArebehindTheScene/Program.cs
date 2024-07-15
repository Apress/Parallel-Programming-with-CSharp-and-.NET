using static System.Console;

WriteLine("Main thread starts.");

var getValue = ExecuteLongTaskAsync();
WriteLine("Main thread continues.");
int result = await getValue;
WriteLine($"The long task returns: {result}");
WriteLine("Main thread ends.");

static async Task<int> ExecuteLongTaskAsync()
{
    WriteLine("Long running method starts.");
    Random random = new();
    await Task.Delay(500);
    WriteLine("Long running method resumes.");
    await Task.Delay(700);
    WriteLine("Long running method resumes again.");
    return random.Next(1, 100);
}
