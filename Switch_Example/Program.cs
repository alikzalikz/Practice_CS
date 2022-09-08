using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Example
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Please Enter Number :");
      int NumberOfWeek = Convert.ToInt32(Console.ReadLine());

      switch (NumberOfWeek)
      {
        case 0:
          {
            Console.WriteLine("Shanbe");
            break;
          }
        case 1:
          {
            Console.WriteLine("YeckShanbe");
          break;
          }
        case 2:
          {
            Console.WriteLine("DoShanbe");
            break;
          }
        case 3:
          {
            Console.WriteLine("SeShanbe");
            break;
          }
        case 4:
          {
            Console.WriteLine("ChaharShanbe");
            break;
          }
        case 5:
          {
            Console.WriteLine("PanjShanbe");
            break;
          }
        case 6:
          {
            Console.WriteLine("Jome");
            break;
          }
        default:
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not Found!");
            Console.ResetColor();
            break;
          }

      }

      Console.ReadKey();

    }
  }
}
