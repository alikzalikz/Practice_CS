using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrey_Example
{
  class Program
  {
    static void Main(string[] args)
    {
      
      int[] numbers = {1, 2, 3, 4}; // start counting from 0!

      int number = numbers[2]; // number = 3

      string[] Names = {"Reza", "Ali", "Iman"};

      for(int n = 0; n <= 2; n++)
      {
        Console.WriteLine(Names[n]); // teach code

//          string name = Names[n];  // my code
//          Console.WriteLine(name);
      }
      
      Console.ReadKey();


    }
  }
}
