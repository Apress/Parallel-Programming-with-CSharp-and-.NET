using static System.Console;

WriteLine("Exercise 6.10");
string url = "https://www.aboutamazon.in/what-we-do/amazon-pay";
var webContent = PrintContents(url);
WriteLine("Shortly, you'll see the content...");
WriteLine(webContent.Result);
ReadKey();

static async Task<string> PrintContents(string url)
{
    var client = new HttpClient();
    var contents = await client.GetStringAsync(url);
    return contents;

    // DO NOT USE
    // // WebClient is obsolete
    //var client = new WebClient(); 
    //var contents = await client.DownloadStringTaskAsync(url);
    //return contents;
}
