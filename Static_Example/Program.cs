using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass c1 = new MyClass();
            c1.name = "ali";
            c1.family = "koleiny zadeh"System.;
            MyClass.website = "google.cSystem.om";
            // int sum = c1.Sum(5, 6);  // When we dont use static on MyClass
            int sum = MyClass.Sum(5, 6);
            
            Console.WriteLine(Ali.sitename);
            Console.WriteLine(Ali.siteurl);

            Console.ReadKey();
        }
    }
}
