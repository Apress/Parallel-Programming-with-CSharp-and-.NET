using static System.Console;

const string appName = "MyApp";
Mutex mutex;
try
{
    mutex = Mutex.OpenExisting(appName);
    // If the previous line succeeds, we can run the following line.
    WriteLine($"An instance of the application {appName} is already running!");
    return;
}
catch (WaitHandleCannotBeOpenedException)
{ 
  // Since the mutex is unavailable, we can create it
    mutex = new(false, appName);
}

// The mutex is already created. Trying to get it before launching the app.

bool getMutex = mutex.WaitOne(5000);
if (getMutex)
{
    try
    {
        // Launching the application now
        LaunchApplication();
    }
    finally
    {
        WriteLine($"Press the 'Enter' key to close the app.");
        ReadKey();
        mutex.ReleaseMutex();
    }
}

void LaunchApplication()
{
    WriteLine($"Starting the {appName} application"); 
    // Do something, if needed
}












