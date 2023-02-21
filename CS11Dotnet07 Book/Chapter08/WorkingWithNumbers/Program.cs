using System.Numerics;

WriteLine("Working with large integers:");
WriteLine("----------------------------------------");

ulong big = ulong.MaxValue;
WriteLine($"{big,40:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,40:N0}");

WriteLine("Working with complex numbers:");

Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

WriteLine($"{c1} added to {c2} is {c3}");
WriteLine($"{c1.Real} + {c1.Imaginary}i added to {c2.Real} + {c2.Imaginary}i is {c3.Real} + {c3.Imaginary}i");

Random r = Random.Shared;
int dieRoll = r.Next(minValue: 1, maxValue: 7);

double randomReal = r.NextDouble();

byte[] arrayOfByts = new byte[256];
r.NextBytes(arrayOfByts);