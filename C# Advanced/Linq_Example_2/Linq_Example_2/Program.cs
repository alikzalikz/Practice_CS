using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Example_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            Person p1 = new Person();
            p1.PersonID = 1;
            p1.Name = "Ali";
            p1.Family = "Koleiny Zadeh";
            p1.Age = 18;
            people.Add(p1);

            Person p2 = new Person()
            {
                PersonID = 2,
                Name = "Mahdi",
                Family = "Eivazi",
                Age = 19
            };
            people.Add(p2);

            people.Add(new Person() { PersonID = 3, Name = "sara", Family = "ahmadi", Age = 25 });

            // query with lambda

            //var result = people.ToList();
            //var result = people.OrderByDescending(p => p.Age).ToList();
            //var result = people.Where(p => p.Name.ToLower()=="ali").ToList();
            var result = people.Where(p => p.Age >= 19 && p.Age <= 30).OrderByDescending(p => p.Age).ToList();
            var result2 = people.Select(p => p.Name).ToList();
            var result3 = people.Select(p => new { p.Name, p.Family }).ToList();

            foreach (var p in result)
            {
                Console.WriteLine($"ID: {p.PersonID}    Name: {p.Name}     Family: {p.Family}     Age: {p.Age}");
            }


            List<PersonCar> Cars = new List<PersonCar>()
            {
                new PersonCar(){ PersonID = 1, CarName = "Pride", CarModel = "1388" },
                new PersonCar(){ PersonID = 2, CarName = "L90", CarModel = "1391" }
            };

            var join = (from p in people
                        join c in Cars on p.PersonID equals c.PersonID
                        select new
                        {
                            p.PersonID,
                            p.Name,
                            p.Family,
                            p.Age,
                            c.CarName,
                            c.CarModel
                        }).ToList();

            int[] numbers = { 1, 2, 3, 3, 3, 4, 7, 10, 5, 1 };
            var res1 = numbers.Distinct().ToArray();

            var res2 = numbers.OrderByDescending(n => n).Take(3).ToArray();
            var res3 = numbers.OrderByDescending(n => n).Skip(3).ToArray();
            var res4 = numbers.OrderByDescending(n => n).Skip(3).Take(3).ToArray();

            Console.ReadKey();
        }
    }
}
