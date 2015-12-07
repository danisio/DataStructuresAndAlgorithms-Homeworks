/*A large trade company has millions of articles, each described by barcode, vendor, title and price.
Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.*/

namespace Company
{
    using System;
    using System.Diagnostics;

    public class Startup
    {
        private static readonly Random Rnd = new Random();
        private static readonly Stopwatch Sw = new Stopwatch();

        public static void Main()
        {
            var store = new Company();

            Console.WriteLine("Adding 500 000 articles...");
            Sw.Start();
            AddProducts(store);
            Sw.Stop();

            Console.WriteLine("Elapsed time: {0}", Sw.Elapsed);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Searching 10 000 000 products in given range....");
            Sw.Restart();
            SearchArticles(store);
            Sw.Stop();

            Console.WriteLine("Elapsed time: {0}", Sw.Elapsed);
        }

        private static void AddProducts(Company store, int numOfProductsToAdd = 500000)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string title = Rnd.Next(int.MaxValue).ToString();
                string vendor = title + i;
                decimal price = Rnd.Next(20000) / 100;
                decimal barcode = Rnd.Next(1000000, int.MaxValue) * 2;
                store.AddProduct(new Article(title, vendor, price, barcode));
            }
        }

        private static void SearchArticles(Company company, int searchCounter = 10000000)
        {
            for (int i = 0; i < searchCounter; i++)
            {
                int min = Rnd.Next(100);
                int max = Rnd.Next(5000, 10000);
                company.SearchInPriceRange(min, max);
            }
        }
    }
}
