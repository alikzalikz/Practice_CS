using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_Example 
{
  class Program
  {
    static void Main(string[] args)
    {
      // ==
      // !=
      // >
      // <
      // >=
      // <=
      
      string name = "";
      string family = "";

      Console.WriteLine("Please Enter Your Name :");
      name = Console.ReadLine().ToLower(); 

      Console.WriteLine("Please Enter Your Family");
      family = Console.ReadLine().ToLower();

      if (name == "ali" || family == "koleiny")
      {
        Console.WriteLine("Hello AliKZ07");  
        Console.WriteLine("Modir Modire Kheili Modire");
      }
      else
      {
      Console.WriteLine("Hello New User :)");
      }
      Console.ReadKey();
    }
  }
}
