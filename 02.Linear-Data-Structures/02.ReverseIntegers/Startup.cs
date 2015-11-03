/*Write a program that reads N integers from the console and reverses them using a stack.
Use the Stack<int> class.*/

namespace ReverseIntegers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new Stack<int>();

            Console.WriteLine("Enter some numbers: ");
            var line = Console.ReadLine();

            while (line != string.Empty)
            {
                var number = int.Parse(line);
                numbers.Push(number);

                line = Console.ReadLine();
            }
            
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
