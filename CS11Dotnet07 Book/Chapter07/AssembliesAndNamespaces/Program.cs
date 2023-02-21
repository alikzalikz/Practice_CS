using System; // String
using System.Xml.Linq; // XDocument
using Packt.Shared;

XDocument doc = new();

string s1 = "Hello";
String s2 = "World";
WriteLine($"{s1} {s2}");

WriteLine($"int.MaxValue = {int.MaxValue}");
WriteLine($"nint.MaxValue = {nint.MaxValue}");

Write("Enter a color value in hex: ");
string? hex = ReadLine();
WriteLine($"Is {hex} a valid color value? {hex.IsValidHex()}");