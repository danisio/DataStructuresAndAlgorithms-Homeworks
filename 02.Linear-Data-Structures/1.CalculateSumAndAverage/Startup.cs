/*Write a program that reads from the console a sequence of positive integer numbers.
The sequence ends when empty line is entered.
Calculate and print the sum and average of the elements of the sequence.
Keep the sequence in List<int>.*/

namespace CalculateSumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            Console.WriteLine("Average: {0}", numbers.Average());
            Console.WriteLine("Sum: {0}", numbers.Sum());
        }
    }
}
