using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticConstructor_Example
{
    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("pubilc constructor ....");
        }

        // static constructor just run one time!
        static MyClass()
        {
            Console.WriteLine("static constructor ....");
        }
    }
}
