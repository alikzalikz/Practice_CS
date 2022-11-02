using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EF_DBEntities db = new EF_DBEntities();

            // insert
            //Person p1 = new Person()
            //{
            //    Name = "Mahdi",
            //    Family = "Eivazi",
            //    Age = 19
            //};
            //db.People.Add(p1);

            var res = db.People.SingleOrDefault(p => p.PersonID == 4);
            if (res != null)
            {
                res.Age = 20;
            }
            db.People.Remove(res);

            db.SaveChanges();

            //var list = db.People.ToList();
            //var list = db.People.Where(p => p.Age > 20).ToList();
            var list = db.People.OrderByDescending(p => p.Age).ToList();

            foreach (Person p in list)
            {
                Console.WriteLine($"ID: {p.PersonID}  Name: {p.Name}  Family: {p.Family}  Age: {p.Age}");
            }
        }
    }
}
