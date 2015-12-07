/*Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b].
Test for 500 000 products and 10 000 price searches.
Hint: you may use OrderedBag<T> and sub-ranges.*/

namespace ProcessingCollections
{
    using System;
    using System.Diagnostics;

    public static class Startup
    {
        private static readonly Random Rnd = new Random();
        private static readonly Stopwatch Sw = new Stopwatch();

        public static void Main()
        {
            var store = new Store();

            Console.WriteLine("Adding 500 000 products... ");
            Sw.Start();
            AddProducts(store);
            Sw.Stop();

            Console.WriteLine("Elapsed time: {0}", Sw.Elapsed);
            Console.WriteLine("------------------------------");
            Console.WriteLine("10 000 price searches...");
            Sw.Restart();
            SearchInPriceRange(store);
            Sw.Stop();

            Console.WriteLine("Elapsed time: {0}\n", Sw.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = 500000)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string name = Rnd.Next(int.MaxValue).ToString();
                decimal price = Rnd.Next(20000) / 100;
                store.AddProduct(new Product(name, price));
            }
        }

        private static void SearchInPriceRange(Store store, int numOfSearches = 10000)
        {
            for (int i = 0; i < numOfSearches; i++)
            {
                int min = Rnd.Next(200), max = Rnd.Next(400, 1000);

                store.SearchInPriceRange(min, max);
            }
        }
    }
}
