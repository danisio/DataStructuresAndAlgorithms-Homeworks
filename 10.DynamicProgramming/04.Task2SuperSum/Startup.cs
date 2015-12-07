namespace Task2SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {

        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            int k = numbers[0];
            int n = numbers[1];

            Console.WriteLine(SuperSum(k, n));
        }

        static long SuperSum(int k, int n)
        {
            if (k == 1)
            {
                int sum = 0;

                for (int i = 1; i <= n; i++)
                {
                    sum += i;
                }

                return sum;
            }

            long currentSum = 0;

            for (int i = 1; i <= n; i++)
            {
                currentSum += SuperSum(k - 1, i);
            }

            return currentSum;
        }
    }
}
