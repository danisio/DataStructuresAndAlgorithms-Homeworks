﻿/*We are given numbers N and M and the following operations:
N = N+1
N = N+2
N = N*2
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
Hint: use a queue.
Example: N = 5, M = 16
Sequence: 5 → 7 → 8 → 16*/

namespace FindShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var result = new Queue<int>();

            int start = 5;
            int end = 16;

            while (start <= end)
            {
                result.Enqueue(end);

                if (end / 2 >= start)
                {
                    if (end % 2 == 0)
                    {
                        end /= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    if (end - 2 >= start)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            Console.WriteLine(string.Join(" -> ", result.Reverse()));
        }
    }
}
