using System.Security.Cryptography.X509Certificates;
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

WriteLine("----------------");

Person?[] people =
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
};

OutputPeopleNames(people, "Initial list of people");

Array.Sort(people);
OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");

WriteLine("----------------");

Array.Sort(people, new PersonComparer());
OutputPeopleNames(people, "After sorting using PersonComparer's IComparer implementation:");

WriteLine("----------------");

string ShowVector(DisplacementVector vector)
{
    return $"({vector.X}, {vector.Y})";
}

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"{ShowVector(dv1)} + {ShowVector(dv2)} = {ShowVector(dv3)}");

WriteLine("----------------");

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year:1990, month:07, day:28)
};
john.WriteToConsole();
john.EmployeeCode = "JJ002";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name}was hired on {john.HireDate:dd/MM/yy}");

WriteLine("----------------");

WriteLine(john.ToString());

WriteLine("----------------");

Employee aliceInEmployee = new(){ Name = "Alice", EmployeeCode = "AA123" };

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

WriteLine("----------------");

Employee explicitAlice = (Employee)aliceInPerson;

WriteLine("----------------");

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}

WriteLine("----------------");

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine($"{email1} is a valid e-mail address: {StringExtensions.IsValidEmail(email1)}");
WriteLine($"{email2} is a valid e-mail address: {StringExtensions.IsValidEmail(email2)}");

WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}");
WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}");