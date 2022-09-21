using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Car pride = new Car();
            pride.Speed = 120;
            // pride.CarName = "Peykan";  // Read-Only
            
            System.Console.WriteLine($"Car Name Is {pride.CarName}"); 
            System.Console.WriteLine($"Speed Is {pride.Speed}");
            System.Console.ReadKey();
        }
    }
}
