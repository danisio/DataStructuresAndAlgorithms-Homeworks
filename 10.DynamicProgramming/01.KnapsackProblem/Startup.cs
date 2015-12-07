/*Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. The numbers N, M, Wi and Ci are integers in the range [1..500].

Example: M=10kg, N=6, products:
beer – weight=3, cost=2
vodka – weight=8, cost=12
cheese – weight=4, cost=5
nuts – weight=1, cost=4
ham – weight=2, cost=3
whiskey – weight=8, cost=13
Optimal solution:
nuts + whiskey
weight = 9
cost = 17*/
namespace KnapsackProblem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    namespace KnapsackProblem
    {
        public class Startup
        {
            private static readonly List<Product> solution = new List<Product>();

            private static Product[] products;
            private static int[,] valueTable;
            private static int[,] keptTable;
            private static int capacity;

            private static void Main(string[] args)
            {
                products = new Product[]
                {
                new Product("Beer",3,2),
                new Product("Vodka",8,12),
                new Product("Cheese",4,5),
                new Product("Nuts",1,4),
                new Product("Ham",2,3),
                new Product("Whiskey",8,13)
                };

                capacity = 10;
                valueTable = new int[products.Length + 1, capacity + 1];
                keptTable = new int[products.Length + 1, capacity + 1];

                GetValues();

                GetSolution();

                Console.WriteLine(string.Format(
                    "Best cost: {0}, best weight = {1}",
                    valueTable[products.Length, capacity],
                    solution.Select(p => p.Weight).Sum()));

                Console.WriteLine();
                foreach (var item in solution)
                {
                    Console.WriteLine(item);
                }
            }

            private static void GetValues()
            {
                for (int i = 1; i <= products.Length; i++)
                {
                    for (int j = 1; j <= capacity; j++)
                    {
                        if (products[i - 1].Weight <= j)
                        {
                            if (products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight] > valueTable[i - 1, j])
                            {
                                valueTable[i, j] = products[i - 1].Cost + valueTable[i - 1, j - products[i - 1].Weight];
                                keptTable[i, j] = 1;
                            }
                            else
                            {
                                valueTable[i, j] = valueTable[i - 1, j];
                            }
                        }
                    }
                }
            }

            private static void GetSolution()
            {
                var itemsCount = products.Length;
                var capacityLeft = capacity;

                while (itemsCount > 0)
                {
                    if (keptTable[itemsCount, capacityLeft] != 0)
                    {
                        solution.Add(products[itemsCount - 1]);
                        capacityLeft -= products[itemsCount - 1].Weight;
                    }

                    itemsCount--;
                }
            }
        }
    }
}
