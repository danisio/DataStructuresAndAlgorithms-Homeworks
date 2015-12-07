namespace Task1Tribonacci
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var numbers = new long[] { input[0], input[1], input[2] };

            long searchedIndex = input[3] - 1;
            long currentIndex = 3;

            while (searchedIndex >= currentIndex)
            {
                numbers[currentIndex++ % numbers.Length] = numbers.Sum();
            }

            Console.WriteLine(numbers[(searchedIndex) % numbers.Length]);
        }
    }
}
