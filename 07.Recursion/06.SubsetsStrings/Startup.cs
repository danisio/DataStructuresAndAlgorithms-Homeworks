namespace SubsetsStrings
{
    using System;

    public class Startup
    {
        private const int K = 2;
        private static readonly string[] elements = { "test", "rock", "fun" };
        private static readonly int n = elements.Length;
        private static readonly int[] variations = new int[n];

        public static void Main()
        {
            Variations(0, 0);
        }

        private static void Variations(int start, int depth)
        {
            if (depth >= K)
            {
                Print();
                return;
            }

            for (int i = start; i < n; i++, start++)
            {
                variations[depth] = i;
                Variations(start + 1, depth + 1);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(elements[variations[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
