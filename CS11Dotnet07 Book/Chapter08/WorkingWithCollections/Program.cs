using System.Collections.Immutable;

List<string> cities = new();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

Output("Inital List", cities);
WriteLine($"the first city is {cities[0]}.");
WriteLine($"the last city is {cities[cities.Count - 1]}.");

WriteLine("------------------------------");

cities.Insert(0, "Sydney");
Output("after inseting Sydney at index 0", cities);

WriteLine("------------------------------");

cities.RemoveAt(0);
cities.Remove("Milan");
Output("after removing two cities", cities);

WriteLine("------------------------------");
WriteLine("------------------------------");

Dictionary<string, string> keywords = new();

keywords.Add(key: "int", value: "32-bit integer data type");
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

Output("Dictionary keys", keywords.Keys);
Output("Dictionary values", keywords.Values);

WriteLine("------------------------------");

WriteLine("keywordss and their definitions");
foreach (KeyValuePair<string, string> item in keywords)
{
    WriteLine($" {item.Key}: {item.Value}");
}

WriteLine("------------------------------");

string key = "long";
WriteLine($"the definition of {key} is {keywords[key]}");

WriteLine("------------------------------");
WriteLine("------------------------------");

Queue<string> coffee = new();

coffee.Enqueue("Damir");
coffee.Enqueue("Andrea");
coffee.Enqueue("Ronald");
coffee.Enqueue("Amin");
coffee.Enqueue("Irina");

Output("intial queue from fron to back", coffee);

string served = coffee.Dequeue();
WriteLine($"Served: {served}.");

served = coffee.Dequeue();
WriteLine($"Served: {served}.");

Output("Current queue from front to back", coffee);

WriteLine($"{coffee.Peek()} is next in line.");

Output("Current queue from front to back", coffee);

WriteLine("------------------------------");
WriteLine("------------------------------");

PriorityQueue<string, int> vaccine = new();

vaccine.Enqueue("Pamela", 1);
vaccine.Enqueue("Rebecca", 3);
vaccine.Enqueue("Juliet", 2);
vaccine.Enqueue("Ian", 1);

OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

WriteLine("Adding Mark to queue with priority 2");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

WriteLine("------------------------------");
WriteLine("------------------------------");

ImmutableList<string> immutableCities = cities.ToImmutableList();
ImmutableList<string> newList = immutableCities.Add("Rio");
Output("Immutable list of cities:", immutableCities);
Output("New list of cities:", newList);