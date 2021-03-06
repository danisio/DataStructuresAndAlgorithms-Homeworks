﻿namespace Task4Guitar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var steps = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            var volume = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[n + 1, maxVolume + 1];
            matrix[0, volume] = true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= maxVolume; j++)
                {
                    if (matrix[i - 1, j])
                    {
                        var currentStep = steps[i - 1];

                        if (j - currentStep >= 0)
                            matrix[i, j - currentStep] = true;

                        if (j + currentStep <= maxVolume)
                            matrix[i, j + currentStep] = true;
                    }
                }
            }

            Console.WriteLine(FindLastMaxVolume(matrix, n));
        }

        static long FindLastMaxVolume(bool[,] matrix, int N)
        {
            for (long j = matrix.GetLongLength(1) - 1; j >= 0; j--)
                if (matrix[N, j])
                    return j;

            return -1;
        }
    }
}

