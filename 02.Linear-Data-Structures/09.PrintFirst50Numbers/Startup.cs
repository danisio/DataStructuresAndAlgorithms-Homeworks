/*We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/

namespace PrintFirst50Numbers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var n = 2;

            queue.Enqueue(n);

            var result = new List<int>();
            for (int i = 1; i <= 50; i++)
            {
                var s1 = queue.Dequeue();
                result.Add(s1);

                var s2 = s1 + 1;
                var s3 = (s1 * 2) + 1;
                var s4 = s1 + 2;

                queue.Enqueue(s2);
                queue.Enqueue(s3);
                queue.Enqueue(s4);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
