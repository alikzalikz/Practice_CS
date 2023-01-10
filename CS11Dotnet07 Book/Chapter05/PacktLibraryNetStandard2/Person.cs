namespace Packt.Shared;


[Flags]
public enum WondersOfTheAncientWorld : byte
{
    None                     = 0b_0000_0000, // i.e. 0
    GreatPyramidOfGiza       = 0b_0000_0001, // i.e. 1
    HangingGardensOfBabylon  = 0b_0000_0010, // i.e. 2
    StatueOfZeusAtOlympia    = 0b_0000_0100, // i.e. 4
    TempleOfArtemisAtEphesus = 0b_0000_1000, // i.e. 8
    MausoleumAtHalicarnassus = 0b_0001_0000, // i.e. 16
    ColossusOfRhodes         = 0b_0010_0000, // i.e. 32
    LighthouseOfAlexandria   = 0b_0100_0000  // i.e. 64
}



public class Person : Object
{
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();
    public const string Species = "Homo Sapiens";
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;
    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }
    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }
    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}.";
    }
    public (string, int) GetFruit()
    {
        return ("apple", 5);
    }
    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }
    public void Deconstruct(out string? name, out DateTime dob)
    {
        name = Name;
        dob = DateOfBirth;
    }
    public void Deconstruct(out string? name, out DateTime dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = DateOfBirth;
        fav = FavoriteAncientWonder;
    }
    public string SayHello()
    {
        return $"{Name} says 'Hello'";
    }
    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }
    public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
    {
        return $"command is {command}, number is {number}, active is {active}";
    }
    public void PassingParameters(int x, ref int y, out int z)
    {
        z = 99;
        x++;
        y++;
        z++;
    }
}