/*Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2 → 2 times
3 → 4 times
4 → 3 times*/

namespace FindOccurences
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>();

            Console.WriteLine("Enter some numbers: ");
            var line = Console.ReadLine();

            while (line != string.Empty)
            {
                var number = int.Parse(line);
                numbers.Add(number);

                line = Console.ReadLine();
            }

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

            foreach (var num in result)
            {
                Console.WriteLine("number {0, 4} --> {1} times", num.Key, num.Value);
            }
        }
    }
}
