/*
 Task 3 - Dividers
http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012
*/
namespace Dividers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static readonly HashSet<int> Permutted = new HashSet<int>();
        private static readonly Dictionary<int, int> Dividers = new Dictionary<int, int>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers[i] = num;
            }

            GeneratePermutations(numbers, 0);
            FindDividers();

            int result = Dividers
                .OrderBy(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .FirstOrDefault();

            Console.WriteLine(result);
        }

        private static void FindDividers()
        {
            foreach (var item in Permutted)
            {
                int count = 0;
                for (int i = 1; i < item; i++)
                {
                    if (item % i == 0)
                    {
                        count++;
                    }
                }

                Dividers.Add(item, count);
            }
        }

        private static void GeneratePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Permutted.Add(int.Parse(string.Join(string.Empty, arr)));
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap(ref int first, ref int second)
        {
            first ^= second;
            second ^= first;
            first ^= second;
        }
    }
}
