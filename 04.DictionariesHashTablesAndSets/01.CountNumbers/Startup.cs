/*Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
-2.5 -> 2 times
3 -> 4 times
4 -> 3 times*/

namespace CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif

            var result = new SortedDictionary<double, int>();

            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToList();

            foreach (var num in input)
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

            foreach (var item in result)
            {
                Console.WriteLine("{0, 6} --> {1, 2} times", item.Key, item.Value);
            }
        }
    }
}
