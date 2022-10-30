using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();

            Console.WriteLine(my.Sum(6, 5));
            Console.WriteLine(my.Minus(6, 5));

            Console.ReadKey();
        }
    }
}
