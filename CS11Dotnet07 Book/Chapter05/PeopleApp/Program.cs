using System.Reflection.Metadata.Ecma335;
using Packt.Shared;

Person bob = new();
//WriteLine(bob.ToString());

bob.Name = "bob";
bob.DateOfBirth = new DateTime(1965, 12, 22);

WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}", arg0: bob.Name, arg1: bob.DateOfBirth);

// bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.GreatPyramidOfGiza | WondersOfTheAncientWorld.TempleOfArtemisAtEphesus;
// bob.BucketList = (WondersOfTheAncientWorld)9;

// WriteLine(format: $"{bob.Name}'s favorite wonder is {bob.FavoriteAncientWonder}. Its integer is {(int)bob.FavoriteAncientWonder}.");
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

WriteLine($"{bob.Name} is {Person.Species}");

WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

bob.Children.Add(new() {Name = "Alfred"});
bob.Children.Add(new() {Name = "Zoe"});

WriteLine($"bob's children are:");
// for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
// {
//     WriteLine($"> {bob.Children[childIndex].Name}");
// }
foreach (var p in bob.Children)
{
    WriteLine($"> {p.Name}");
}

WriteLine("----------------");

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-GB");

BankAccount.InsertRate = 0.012M;

BankAccount JonseAccunt = new()
{
    AccuntName = "Mrs. Jones",
    Balanced = 2400
};
WriteLine($"{JonseAccunt.AccuntName} earned {JonseAccunt.Balanced * BankAccount.InsertRate:C} Insert");

BankAccount GerrierAccunt = new()
{
    AccuntName = "Ms. Gerrier",
    Balanced = 98
};
WriteLine($"{GerrierAccunt.AccuntName} earned {GerrierAccunt.Balanced * BankAccount.InsertRate:C} Insert");

WriteLine("----------------");

Person BlankPerson = new();
WriteLine($"{BlankPerson.Name} of {BlankPerson.HomePlanet} was created at {BlankPerson.Instantiated:hh:mm:ss} on a {BlankPerson.Instantiated:dddd}.");

WriteLine("----------------");

Person gunny = new(initialName: "Gunny", homePlanet: "mars");
WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}.");

WriteLine("----------------");

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

WriteLine("----------------");

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are");

WriteLine("----------------");

var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

WriteLine("----------------");

var (name1, dob1) = bob;
WriteLine($"Deconstructed: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

WriteLine("----------------");

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Ali"));

WriteLine("----------------");

WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters(active: false,command: "cd!"));

WriteLine("----------------");

int a = 10;
int b = 10;
int c = 10;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");

WriteLine("----------------");

int d = 10;
int e = 20;
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");

bob.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");

WriteLine("----------------");

Person Sam = new()
{
    Name = "Sam",
    DateOfBirth = new(1969, 6, 25) 
};
WriteLine(Sam.Origin);
WriteLine(Sam.Greeting);
WriteLine(Sam.Age);

Sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {Sam.FavoriteIceCream}.");

string color = "Red";

try
{
    Sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favorite primary color is {Sam.FavoritePrimaryColor}.");
}
catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}': {2}",
    nameof(Sam.FavoritePrimaryColor), color, ex.Message);
}

WriteLine("----------------");

Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 11 and .NET 7 - Modern Cross-Platform Development Fundamentals"
};

WriteLine($"{book.Isbn}: {book.Title} written by {book.Author} has {book.PageCount:N0} pages.");

WriteLine("----------------");

Sam.Children.Add(new() {Name = "Ella", DateOfBirth = new(2020, 12, 24)});
Sam.Children.Add(new() {Name = "Charlie", DateOfBirth = new(2010, 03, 18)});

WriteLine($"Sam's child named Ella is {Sam["Ella"].Age} years old.");

WriteLine("----------------");

Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

lamech.Marry(adah);
Person.Marry(zillah, lamech);

WriteLine($"{lamech.Name} is married to {lamech.Spouse?.Name ?? "nobody"}");
WriteLine($"{adah.Name} is married to {adah.Spouse?.Name ?? "nobody"}");
WriteLine($"{zillah.Name} is married to {zillah.Spouse?.Name ?? "nobody"}");

Person baby1 = lamech * adah;
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.DateOfBirth}");

Person baby2 = zillah * lamech;
baby2.Name = "Tubalcain";

WriteLine($"{lamech.Name} has {lamech.Children.Count} children.");
WriteLine($"{adah.Name} has {adah.Children.Count} children.");
WriteLine($"{zillah.Name} has {zillah.Children.Count} children.");

int count = 1;
foreach (var i in lamech.Children)
{
    WriteLine($"{lamech.Name}'s child #{count} is named \"{i.Name}\".");
    count++;
}

WriteLine("----------------");

if (lamech + zillah)
{
    WriteLine($"{zillah.Name} and {lamech.Name} successfully got married.");
}