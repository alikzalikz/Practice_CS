using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass_Example
{
    partial class MyClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
