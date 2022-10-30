using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Example
{
  class Person
  {
    public string name;
    public string family;
    public string website;

    public Person(string name, string family, string website) // I have this error in first run: "inaccessible due to its protection level" but solve it with stackoverflow.com :)
    {                                                         // Every members in C# are implicitly private 
      this.name = name;
      this.family = family;
      this.website = website;
    }

  }
}
