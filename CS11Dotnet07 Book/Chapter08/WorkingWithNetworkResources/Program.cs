using System.Security.AccessControl;
using System.Net;
using System.Net.NetworkInformation;

Write("Enter a valid a web address (or press Enter)");
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = "https://stackoverflow.com/search?q=securestring";
}

Uri uri = new(url);
WriteLine($"URL: {url}");
WriteLine($"Scheme: {uri.Scheme}");
WriteLine($"Port: {uri.Port}");
WriteLine($"Host: {uri.Host}");
WriteLine($"Path: {uri.AbsolutePath}");
WriteLine($"Query: {uri.Query}");

WriteLine("------------------------------");

IPHostEntry entry = Dns.GetHostEntry(uri.Host);
WriteLine($"{entry.HostName} has the following IP addresses:");
foreach (var address in entry.AddressList)
{
    WriteLine($" {address} ({address.AddressFamily})");
}

WriteLine("------------------------------");

try
{
    Ping ping = new();
    
    WriteLine("Pinging server. Please wait...");
    PingReply reply = ping.Send(uri.Host);
    WriteLine($"{uri.Host} was pinged and replied: {reply.Status}.");
    
    if (reply.Status == IPStatus.Success)
    {
        WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime:N0}ms");
    }
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}