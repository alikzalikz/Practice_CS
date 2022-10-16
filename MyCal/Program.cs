using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCal 
{
  class Program
  {
    static void Main(string[] args)
    {
	    Console.WriteLine("Please Enter Number1 :");
      int Number1 =int.Parse( Console.ReadLine()); 
	    Console.WriteLine("Please Enter Number2 :");
      int Number2 =int.Parse(Console.ReadLine());
      
      //int num1 = Convert.ToInt32(Number1);
      //int num2 = Convert.ToInt32(Number2);

      int sum = Number1 + Number2;
      //Console.WriteLine("Sum is :{0}",sum);
      Console.WriteLine($"sum is : {sum}");

      Console.ReadKey();
    }
  }
}
