namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int length = collection.Count;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (collection[i].CompareTo(collection[j]) > 0)
                    {
                        T tmp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = tmp;
                    }
                }
            }
        }
    }
}
