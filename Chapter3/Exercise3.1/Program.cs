using static System.Console;
using System.Collections.Concurrent;

var colorBag = new ConcurrentDictionary<int,string>();
colorBag.TryAdd(1, "Red");
colorBag.TryAdd(2, "Green");
string color=colorBag.GetOrAdd(2, "Blue");
WriteLine(color);