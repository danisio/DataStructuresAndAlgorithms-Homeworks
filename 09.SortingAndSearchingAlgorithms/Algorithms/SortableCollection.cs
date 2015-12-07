namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static readonly Random Random = new Random();
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get { return this.items; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T currItem in this.items)
            {
                if (item.CompareTo(currItem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count - 1;
            int middle = 0;

            while (left <= right)
            {
                middle = left + ((right - left) / 2);

                if (this.items[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (this.items[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            int lenght = this.items.Count;

            for (int i = this.items.Count; i > 1; i--)
            {
                int j = Random.Next(i);

                T tmp = this.items[j];
                this.items[j] = this.items[i - 1];
                this.items[i - 1] = tmp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}