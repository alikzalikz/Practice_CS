using System.Text.RegularExpressions; // Regex

Write("Enter your age: ");
string input = ReadLine()!;

Regex ageChecker = DigitsOnly();
if (ageChecker.IsMatch(input))
{
    WriteLine("Thank you!");
}
else
{
    WriteLine($"this is not valid age: {input}");
}

string films = """
"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
""";
WriteLine($"films to split: {films}");

WriteLine("Splitting with string.Split method:");
string[] filmsDumb = films.Split(',');
foreach(string film in filmsDumb)
{
    WriteLine(film);
}

WriteLine("Splitting with regular expression:");
Regex csv = commaSeprator();
MatchCollection filmsSmart = csv.Matches(films);
foreach (Match film in filmsSmart)
{
    WriteLine(film.Groups[2].Value);
}