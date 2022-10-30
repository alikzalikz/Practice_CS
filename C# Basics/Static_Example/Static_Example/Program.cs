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
            MyClass ali = new MyClass("ali", "koleiny zadeh", "google.com");
            Console.WriteLine($"Name is: {ali.name}     Family is: {ali.family}     WebSite is: {ali.website}");

            Console.WriteLine(MyClass.Sum(5, 6));
            Console.WriteLine(Ali.SiteName);
            Console.WriteLine(Ali.SiteUrl);
            Console.ReadKey();
        }
    }
}