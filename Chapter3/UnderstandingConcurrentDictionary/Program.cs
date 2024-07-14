using static System.Console;
using System.Collections.Concurrent;

var fifaWCTitles = new ConcurrentDictionary<string, int>();

fifaWCTitles["Brazil"] = 5;
fifaWCTitles["Germany"] = 4;
fifaWCTitles["Argentina"] = 2; // Will be updated to 3 later

fifaWCTitles.TryAdd("Italy", 4);

fifaWCTitles.TryAdd("Argentina", 3); // will not update

//fifaWCTitles.AddOrUpdate("Argentina", 2, (key, oldValue) => 3);

fifaWCTitles.AddOrUpdate(
    "Argentina",
    2,
    (key, oldValue) =>
        {
            int newValue = 3;
            WriteLine($"{key}'s old value {oldValue} is updated to new value {newValue}.");
            return newValue;
        }
 );

int value=fifaWCTitles.GetOrAdd("France", 2); // Successful
WriteLine(value); // 2
fifaWCTitles.GetOrAdd("France", 3); // Unsuccessful
WriteLine(value); // Still 2

//string tryRemoving = "France";
TryRemovingCountryDetails("France");
TryRemovingCountryDetails("Uruguay");

void TryRemovingCountryDetails(string country)
{
    var isRemoved = fifaWCTitles.TryRemove(country, out int removedValue);
    if (isRemoved)
    {
        WriteLine($"{country} with {removedValue} World Cup titles is deleted.");
    }
    else
    {
        WriteLine($"Could not remove the details of {country}");
    }
}

ReadKey();















