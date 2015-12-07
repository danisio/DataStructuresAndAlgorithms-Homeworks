/*Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} and fast search by key1, key2 or by both key1 and key2.
Note: multiple values can be stored for given key.*/

namespace ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var biDict = new BiDictionary<string, string, List<int>>();

            biDict.Add("Ivan", "DSA", new List<int>() { 100, 20, 30 });
            biDict.Add("Pesho", "HQC", new List<int>() { 10, 40, 25 });
            biDict.Add("Gosho", "DSA", new List<int>() { 55, 66, 77 });
            biDict.Add("Gosho", "HQC", new List<int>() { 5, 6, 7 });

            Console.WriteLine("Searching Pesho's scores");
            var result1 = biDict.FindByFirstKey("Pesho");
            foreach (var item in result1)
            {
                Console.WriteLine(string.Join(", ", item));
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Searching for all scores in DSA");
            var result2 = biDict.FindBySecondKey("DSA");
            foreach (var item in result2)
            {
                Console.WriteLine(string.Join(", ", item));
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Searching for DSA's scores of Gosho");
            var result3 = biDict.FindByBothKeys("Gosho", "DSA");
            foreach (var item in result3)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }
    }
}
