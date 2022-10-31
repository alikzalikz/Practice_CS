using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 25000;
            // IQ = 1
            Console.WriteLine(amount.ToString("#,0 Rial"));
            // IQ = 100
            Console.WriteLine(MyClass.ToTooman(amount));
            Console.WriteLine(MyClass.ToTooman(789087));
            // iQ = 100000
            Console.WriteLine(amount.ToTooman());
            Console.WriteLine(89823749.ToTooman());

            // persian calender
            Console.WriteLine(DateTime.Now.ToShamsi());
            Console.ReadKey();
        }
    }
}