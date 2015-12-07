/*Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}*/

namespace OddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
#endif

            var list = new SortedDictionary<string, int>();

            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var word in input)
            {
                if (list.ContainsKey(word))
                {
                    list[word] += 1;
                }
                else
                {
                    list[word] = 1;
                }
            }

            var result = list.Where(n => n.Value % 2 != 0).Select(x => x.Key).ToList();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
