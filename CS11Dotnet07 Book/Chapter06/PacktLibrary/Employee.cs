namespace Packt.Shared;

public class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateTime HireDate { get; set; }

    public new void WriteToConsole()
    {
        WriteLine($"{Name} was born on {DateOfBirth} and was hired on {HireDate}");
    }
    public override string ToString()
    {
        return $"{Name}'s code is {EmployeeCode}";
    }
}