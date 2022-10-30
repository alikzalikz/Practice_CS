using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Example
{
  class Program
  {
    static void Main(string[] args)
    {
      string name = "Ali Koleiny Zadeh";
      Console.WriteLine(name.ToLower());

      SayHello();
      SayHello("ali");

      int sum = Sum(10, 2);
      Console.WriteLine(sum);

      //string fullname = FullName("Ali", "Koleiny Zadeh");  // My code
      //Console.WriteLine(fullname);

      Console.WriteLine(FullName("Ali", "Koleiny Zadeh"));  // Teacher code

      Console.ReadKey();
    }

    static void SayHello()
    {
      Console.WriteLine("Hello User .");
    }

    static void SayHello(string n)  // Method OverLoading
    {
      Console.WriteLine("Hello "+ n);
    }

    static int Sum(int a = 0, int b = 0)
    {
      return a + b;
    }

    static string FullName(string Fname, string Lname)
    {
      return Fname + Lname;
    }
   
  }
}
