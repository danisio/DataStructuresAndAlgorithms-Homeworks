/*Write a program that removes from given sequence all negative numbers.*/

namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int> { -2, 0, -1, 12, 4, -1, 2, 12, -2 };
            var numbersNonNegative = numbers.Where(x => x >= 0);

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(string.Join(", ", numbersNonNegative));
        }
    }
}
