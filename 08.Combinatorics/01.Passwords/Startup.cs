/*
Task 1 - Passwords
http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012
*/

namespace Passwords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            //// Solution --> n ^ k - variations
            //// 2 ^ asterisksCount
            string input = Console.ReadLine();
            int asteriskCount = input.Where(x => x.ToString() == "*").Count();
            var result = (long)Math.Pow(2, asteriskCount);

            Console.WriteLine(result);
        }
    }
}
