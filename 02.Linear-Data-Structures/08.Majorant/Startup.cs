/*The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

Write a program to find the majorant of given array (if exists).
Example:
{2, 2, 3, 3, 2, 3, 4, 3, 3} → 3*/

namespace Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int counterOccurs = (numbers.Count / 2) + 1;

            var result = new SortedDictionary<int, int>();
            foreach (var num in numbers)
            {
                if (result.ContainsKey(num))
                {
                    result[num] += 1;
                }
                else
                {
                    result[num] = 1;
                }
            }

            Console.WriteLine(string.Join(", ", result.Where(n => n.Value >= counterOccurs).Select(n => n.Key)));
        }
    }
}
