using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Namespace_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            PersianCalendar persian = new PersianCalendar();

            string persianDate = persian.GetYear(DateTime.Now) + "/" + persian.GetMonth(DateTime.Now) + "/" + persian.GetDayOfMonth(DateTime.Now);
            Console.WriteLine(persianDate);

            Console.ReadKey();
        }

    }
}
