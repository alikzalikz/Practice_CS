using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Example
{
    class MyClass
    {
        public string name;
        public string family;
        public string website;

        public MyClass(String name, string family, string website)
        {
            this.name = name;
            this.family = family;
            this.website = website;
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
