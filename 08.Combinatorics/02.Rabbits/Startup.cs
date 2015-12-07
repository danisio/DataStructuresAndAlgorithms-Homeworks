/*
 Task 2 - Rabbits
http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012
*/

namespace Rabbits
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var askedRabbits = Console.ReadLine().Split(' ');
            var rabbits = new Dictionary<int, int>();

            for (int i = 0; i < askedRabbits.Length - 1; i++)
            {
                int currentAnswer = int.Parse(askedRabbits[i]);
                if (rabbits.ContainsKey(currentAnswer + 1))
                {
                    rabbits[currentAnswer + 1] += 1;
                }
                else
                {
                    rabbits[currentAnswer + 1] = 1;
                }
            }

            int result = 0;
            foreach (var item in rabbits)
            {
                if (item.Value != 1)
                {
                    int current = (int)Math.Ceiling((double)item.Value / item.Key) * item.Key;
                    //// Console.WriteLine(result);
                    result += current;
                }
                else
                {
                    result += item.Key;
                }
            }

            Console.WriteLine(result);
        }
    }
}
