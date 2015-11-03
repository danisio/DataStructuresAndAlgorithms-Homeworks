/*Write a program that removes from given sequence all numbers that occur odd number of times.
Example:
{4, 2, 2, 5, 2, 1, 3, 2, 3, 1, 5, 2} → {5, 1, 3, 3, 1, 5}*/
namespace RemoveNumbersOccurOddTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var list = new List<int> { 4, 2, 2, 5, 2, 1, 3, 2, 3, 1, 5, 2 };

            var result = RemoveNumbers(list);

            Console.WriteLine(string.Join(", ", result));
        }

        public static IList<int> RemoveNumbers(IList<int> numbers)
        {
            var result = new Dictionary<int, int>();
            
            for (int i = 0; i < numbers.Count; i++)
            {
                var num = numbers[i];

                if (!result.ContainsKey(num))
                {
                    result[num] = 1;
                }
                else
                {
                    result[num]++;
                }
            }

            return numbers.Where(num => result[num] % 2 == 0).ToList();
        }
    }
}
