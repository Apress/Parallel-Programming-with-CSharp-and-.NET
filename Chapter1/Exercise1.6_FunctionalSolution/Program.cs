using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

List<string> websites = ["www.google.com", "www.yahoo.com"];
// Same as:
// List<string> websites = new() { "www.google.com", "www.yahoo.com" };

// Functional style
var task1 = Task.Run(() => PrintHostNameAndIPs(websites));
var task2 = Task.Run(() => PingAll(websites));

Task.WaitAll(task1, task2);

void PrintHostNameAndIPs(List<string> urls)
{
    urls.ForEach(url =>
    {
        IPAddress[] ips = Dns.GetHostAddresses(url);
        WriteLine($"{url}'s IP addresses are:");
        ips.ToList().ForEach(WriteLine);
        WriteLine("--------------");
    });
}
void PingAll(List<string> urls)
{
    urls
    .Select(PingSite)   
    .ToList()
    .ForEach(url => WriteLine($"{url.Address} ping status: {url.Status}  "));
}
static PingReply PingSite(string url)
{
    return new Ping().Send(url);
}
