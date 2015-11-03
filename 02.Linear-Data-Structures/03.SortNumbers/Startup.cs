/*Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.*/

namespace SortNumbers
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

            numbers.Sort();

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
