namespace CombinationsNoDublicates
{
    using System;

    public class Startup
    {
        public const int N = 4;
        public const int K = 2;
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
                    Combinations(index + 1, i + 1);
                }
            }
        }
    }
}
