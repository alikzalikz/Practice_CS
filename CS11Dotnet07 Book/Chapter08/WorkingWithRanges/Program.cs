string name = "Samantha Jones";

int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);
string lastName = name.Substring(startIndex: name.Length - lengthOfLast, length: lengthOfLast);

WriteLine($"First name: {firstName}, Last name: {lastName}");

WriteLine("------------------------------");

ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..^0];

WriteLine($"First name: {firstNameSpan.ToString()}, Last name: {lastNameSpan.ToString()}");