using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticConstructor_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m1 = new MyClass();
            MyClass m2 = new MyClass();
            MyClass m3 = new MyClass();
            MyClass m4 = new MyClass();
            MyClass m5 = new MyClass();

            Console.ReadKey();
        }
    }
}
