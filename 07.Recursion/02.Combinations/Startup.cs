/*Write a recursive program for generating and printing all the combinations with duplicatesof k elements from n-element set. Example:*/

namespace Combinations
{
    using System;

    public class Startup
    {
        public const int N = 3;
        public const int K = 3;
        public static int[] Vector = new int[K];

        public static void Main()
        {
            Combinations(0, 1);
        }

        private static void Combinations(int index, int start)
        {
            if (index >= K)
            {
                Console.WriteLine(string.Join(" ", Vector));
            }
            else
            {
                for (int i = start; i <= N; i++)
                {
                    Vector[index] = i;
                    Combinations(index + 1, i);
                }
            }
        }
    }
}
