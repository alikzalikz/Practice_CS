
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
            
            int[] result2 = (from n in numbers
                             orderby n descending
                             select n).ToArray();
            
            int[] result3 = (from n in numbers
                             where n >= 2 && n <= 3
                             orderby n descending
                             select n).ToArray();
            
            int result4 = (from n in numbers
                           where n == 3
                           select n).FirstOrDefault();
            
            bool result5 = (from n in numbers
                            where n == 6
                            select n).Any();

            var result6 = (from n in numbers
                           orderby n descending
                           select n).ToArray();

            int count = (from n in numbers
                         select n).Count();

            List<string> Names = new List<string>();
            Names.Add("ali");
            Names.Add("sara");
            Names.Add("iman");
            Names.Add("rahim");
            Names.Add("mahin");

            var res7 = (from n in Names
                        select n).ToList();

            var res8 = (from n in Names
                        where n.ToLower().Contains("i")
                        select n).ToList();

            var res9 = (from n in Names
                        where n.ToLower().StartsWith("i")
                        select n).ToList();

            var res10 = (from n in Names
                        where n.ToLower().EndsWith("i")
                        select n).ToList();
        }
    }
}
