using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Example
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Please Enter Number of Person :");
      int nump = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("*******************************");
      Person[] people = new Person[nump];

      for (int i =0; i < nump; i++)
      {
        Console.WriteLine($"Enter Person {(i+1)} Name :");
        string name = Console.ReadLine();
        Console.WriteLine($"Enter Person {(i+1)} family:");
        string family = Console.ReadLine();
        Console.WriteLine($"Enter Person {(i+1)} Website :");
        string website = Console.ReadLine();
        Console.WriteLine("*******************************");

        Person P = new Person(name, family, website);
        people[i] = P;
      }

      Console.ForegroundColor = ConsoleColor.Green;
      foreach (Person person in people)
      {
        Console.WriteLine($"Name: {person.name}  Family: {person.family}  WebSite: {person.website}");
      }
      Console.ResetColor();












//      int sum = MyClass.Sum(5, 6);
//      Console.WriteLine(sum);
//      Console.WriteLine(MyClass.FullName("ali", "Koleiny zadeh"));
//
//      Car car1 = new Car();
//      car1.CarName = "L90";
//      car1.CarSpeed = 160;
//      car1.CarModel = "1400";
//      Car.PrintCar(car1.CarName, car1.CarSpeed, car1.CarModel);
//
//      Car car2 = new Car();
//      car2.CarName = "Peykan";
//      car2.CarSpeed = 100;
//      car2.CarModel = "1360";
//      Car.PrintCar(car2.CarName, car2.CarSpeed, car2.CarModel);
//
//      Person p1 = new Person("ali", "Koleiny", "google.com");
//      Person p2 = new Person("ahmad", "Rezaei", "github.com");
//
//      Console.WriteLine($"Name : {p1.name}\nFamily : {p1.family}\nWebSite :{p1.website}");
//      Console.WriteLine($"Name : {p2.name}\nFamily : {p2.family}\nWebSite :{p2.website}");

      Console.ReadKey();
    }
  }
}
