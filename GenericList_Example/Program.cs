using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            Numbers.Add(5);
            Numbers.Add(6);
            Numbers.Add(7);
            Numbers.Add(8);
            Numbers.Add(9);
            Numbers.Add(10);

            Numbers.Remove(7);
            Numbers.RemoveAt(4); // If you remove dome index, decrement number of index

            List<string> Names = new List<string>();
            Names.Add("ali");
            Names.Add("rahim");
            Names.Add("sara");
            Names.Add("mahin");

            foreach(string name in Names)
            {
                System.Console.WriteLine($"Name Is {name}");
            }
        }
    }
}
