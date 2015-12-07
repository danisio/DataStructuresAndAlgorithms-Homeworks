/*Write a recursive program that simulates the execution of n nested loops from 1 to n.*/

namespace NestedLoops
{
    using System;

    public class Startup
    {
        public const int N = 3;
        public static int[] Vector = new int[N];

        static void Main()
        {
            Loop(0);
        }

        private static void Loop(int index)
        {
            if (index >= N)
            {
                Console.WriteLine(string.Join(" ", Vector));
            }
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    Vector[index] = i;
                    Loop(index + 1);
                }
            }
        }
    }
}
