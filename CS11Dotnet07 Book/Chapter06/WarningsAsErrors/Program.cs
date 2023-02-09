Console.Write("Enter a name: ");
string? name = Console.ReadLine();
if (name == null || name == "")
{
    Console.WriteLine("You did not a name");
    return;
}
Console.WriteLine($"Hello, {name} has {name.Length} characters!");