using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

List<string> websites = ["www.google.com", "www.yahoo.com"];
// Same as:
// List<string> websites = new() { "www.google.com", "www.yahoo.com" };

var task1 = Task.Run(() => PrintHostNameAndIPsOOP(websites));
var task2 = Task.Run(() => PingAllOOP(websites));


Task.WaitAll(task1, task2);

//void PrintHostNameAndIPs(List<string> urls)
//{
//    urls.ForEach(url =>
//    {
//        IPAddress[] ips = Dns.GetHostAddresses(url);
//        WriteLine($"{url}'s ip adresses are:");
//        ips.ToList().ForEach(WriteLine);
//        WriteLine("--------------");

//    });
//}

void PrintHostNameAndIPsOOP(List<string> urls)
{
    foreach (string url in urls)
    {
        IPAddress[] ips = Dns.GetHostAddresses(url);
        WriteLine($"{url}'s IP addresses are:");
        foreach (IPAddress ip in ips)
        {
            WriteLine(ip);
        }
        WriteLine("--------------");

    }
}

//void PingAll(List<string> urls)
//{
//    urls
//    .Select(PingSite)
//    // .Select(url => { return new Ping().Send(url); } ) // OK too
//    .ToList()
//    .ForEach(url => WriteLine($"{url.Address} ping status:{url.Status}  "));

//}

void PingAllOOP(List<string> urls)
{

    List<PingReply> pingReplies = new();
    foreach (string url in urls)
    {
        pingReplies.Add(PingSite(url));
    }
    foreach (PingReply reply in pingReplies)
    {
        WriteLine($"{reply.Address} ping status: {reply.Status}");
    }
}

static PingReply PingSite(string url)
{
    return new Ping().Send(url);
}
