/*Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example:
n=3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}*/

namespace Permutations
{
    using System;

    public class Startup
    {
        public const int N = 4;
        public static readonly int[] permutations = new int[N];
        public static readonly bool[] used = new bool[N + 1];

        public static void Main()
        {
            Permutations(0);
        }

        private static void Permutations(int depth)
        {
            if (depth >= N)
            {
                Console.WriteLine(string.Join(", ", permutations));
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                permutations[depth] = i;
                Permutations(depth + 1);
                used[i] = false;
            }
        }
    }
}
