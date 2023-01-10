using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    DateOfBirth = new(year: 2003, month: 12, day: 26)
};

harry.WriteToConsole();

System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;
WriteLine($"key {key} has value {lookupObject[key]}");
WriteLine($"key {harry} has value {lookupObject[harry]}");

Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");
key  = 3;
WriteLine($"key {key} has value {lookupIntString[key]}");

Person p1 = new();
int answer = p1.MethodIWantToCall("frog");

harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout2;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();