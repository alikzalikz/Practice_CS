namespace Packt.Shared;

public class Person : Object, IComparable<Person?>
{
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }
    public int MethodIWantToCall(string input)
    {
        return input.Length;
    }
    public event EventHandler? Shout;
    public int AngerLevel;
    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel >= 3)
        {
            if (Shout != null)
            {
                Shout(this, EventArgs.Empty);
            }
        }
    }

    public int CompareTo(Person? other)
    {
        int position;
        if ((this is not null) && (other is not null))
        {
            if ((Name is not null) && (other.Name is not null))
            {        
                position = Name.CompareTo(other.Name);
            }
            else if ((Name is not null) && (other.Name is null))
            {
                position = -1; // else this Person precedes other Person
            }
            else if ((Name is null) && (other.Name is not null))
            {
                position = 1; // else this Person follows other Person
            }
            else
            {
                position = 0; // this Person and other Person are at same position
            }
        }
        else if ((this is not null) && (other is null))
        {
            position = -1; // this Person precedes other Person
        }
        else if ((this is null) && (other is not null))
        {
            position = 1; // this Person follows other Person
        }
        else
        {
            position = 0; // this Person and other Person are at same position
        }
        return position;
    }

    public override string ToString()
    {
        return $"{Name} is a {base.ToString()}";
    }

    public void TimeTravel(DateTime when)
    {
        if (when <= DateOfBirth)
        {
            throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!");
        }
        else
        {
            WriteLine($"Welcome to {when:yyyy}!");
        }
    }
}