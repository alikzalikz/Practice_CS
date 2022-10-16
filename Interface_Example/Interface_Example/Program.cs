using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ali ali = new Ali();
            //Console.WriteLine(ali.HelloUser("ali koleiny zadeh"));

            //HiUser hi = new HiUser();
            //Console.WriteLine("ali koleiny zadeh");

            //IMyInterface i1 = new Ali();
            //IMyInterface i2 = new HiUser();

            List<Person> people = new List<Person>();
            
            Person p1 = new Person();
            p1.Name = "ali";
            p1.Family = "koleiny";
            p1.Age = 18;
            people.Add(p1);

            Person p2 = new Person();
            p2.Name = "mahdi";
            p2.Family = "eivazi";
            p2.Age = 19;
            people.Add(p2);

            foreach (Person p in people)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Family: {p.Family}");
                Console.WriteLine($"Age: {p.Age}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*******************");
            }
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}

