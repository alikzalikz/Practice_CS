using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Parent.Sum(5, 6));
            //Console.WriteLine(Parent.Minus(10, 8));

            Console.WriteLine(Child.Sum(10, 8));
            Console.WriteLine(Child.Minus(10, 8));
            Console.WriteLine(Child.Multiple(10, 8));

            Console.ReadKey();
        }
    }
}
