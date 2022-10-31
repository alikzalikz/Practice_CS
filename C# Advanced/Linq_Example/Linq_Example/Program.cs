
// NOTE: work with collection

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            int[] result1 = (from n in numbers select n).ToArray();
            var lambda1 = numbers.ToArray();

            int[] result2 = (from n in numbers
                             orderby n descending
                             select n).ToArray();
            var lambda2 = numbers.OrderByDescending(n => n).ToArray();

            int[] result3 = (from n in numbers
                             where n >= 2 && n <= 3
                             orderby n descending
                             select n).ToArray();
            var lambda3 = numbers.Where(n => n >= 2 && n <= 3).OrderByDescending(n => n).ToArray();


            int result4 = (from n in numbers
                           where n == 3
                           select n).First();
            var lambda4 = numbers.First(n => n == 3);

            int result5 = (from n in numbers
                           where n == 2
                           select n).FirstOrDefault();
            var lambda5 = numbers.FirstOrDefault(n => n == 2);

            int result6 = (from n in numbers
                           where n == 3
                           select n).Single();
            var lambda6 = numbers.Single(n => n == 3);

            int result7 = (from n in numbers
                           where n == 2
                           select n).SingleOrDefault();
            var lambda7 = numbers.SingleOrDefault(n => n == 2);

            bool result8 = (from n in numbers
                            where n == 6
                            select n).Any();
            var lambda8 = numbers.Any(n => n == 6);

            var result9 = (from n in numbers
                           orderby n descending
                           select n).ToArray();
            var lambda9 = numbers.OrderByDescending(n => n).ToArray();

            int Count = (from n in numbers
                         select n).Count();
            var count = numbers.Count();

            List<string> Names = new List<string>();
            Names.Add("ali");
            Names.Add("sara");
            Names.Add("iman");
            Names.Add("rahim");
            Names.Add("mahin");

            var res7 = (from n in Names
                        select n).ToList();
            var lam7 = Names.ToList();

            var res8 = (from n in Names
                        where n.ToLower().Contains("i")
                        select n).ToList();
            var lam8 = Names.Where(n => n.ToLower().Contains("i")).ToList();

            var res9 = (from n in Names
                        where n.ToLower().StartsWith("i")
                        select n).ToList();
            var lam9 = Names.Where(n => n.ToLower().StartsWith("i")).ToList();

            var res10 = (from n in Names
                         where n.ToLower().EndsWith("i")
                         select n).ToList();
            var lam10 = Names.Where(n => n.ToLower().EndsWith("i")).ToList();
        }
    }
}
