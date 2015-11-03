/*Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
Write a program to test whether the method works correctly.*/

namespace FindSubsequence
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

            Console.WriteLine(string.Join(", ", FindSubsequence(numbers)));
        }

        private static ICollection<int> FindSubsequence(IList<int> numbers)
        {
            var currentLength = 1;
            var maxLength = 1;
            var endIndex = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        endIndex = i;
                    }
                }
                else
                {
                    currentLength = 1;
                }
            }

            var startIndex = endIndex - (maxLength - 1);
            var result = new List<int>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }
    }
}
