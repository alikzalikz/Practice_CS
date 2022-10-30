using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_Example
{
  class Program
  {
    static void Main(string[] args)
    {
	    int a = 20;
      string test = Convert.ToString(a);

      string num1 = "22";
      int num = Convert.ToInt32(num1);
      //num = num + 22;
      num ++;
      
      string s1 = "True";
      bool IsActive = Convert.ToBoolean(s1);
      Console.WriteLine(test);
      Console.WriteLine(num);
      Console.WriteLine(IsActive);
      Console.ReadKey();
    }
  }
}
