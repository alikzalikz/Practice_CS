using System.Diagnostics;
using Microsoft.Extensions.Configuration;

string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
Console.WriteLine($"Writing to: {logPath}");
TextWriterTraceListener logFile = new(File.CreateText(logPath));
Trace.Listeners.Add(logFile);
Trace.AutoFlush = true;

// for (int i = 0; i < 10; i++)
// {
//     Debug.WriteLine($"i = {i}");
//     Trace.WriteLine("Trace says, I am watching!");
// }

Trace.WriteLine("Trace says, I am watching!");

// dotnet run: both trace and debug
// dotnet run --configuration Release: just traceing


Console.WriteLine($"Reading from appsettings.json in {Directory.GetCurrentDirectory()}");

ConfigurationBuilder builder = new();

builder.SetBasePath(Directory.GetCurrentDirectory());

builder.AddJsonFile("appsetings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(displayName: "PacktSwitch", description: "This switch is set via a JSON config.");

configuration.GetSection("PacktSwitch").Bind(ts);

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace information");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");

int unitsInStock = 12;
LogSourceDetails(unitsInStock > 10);

Console.ReadLine();
