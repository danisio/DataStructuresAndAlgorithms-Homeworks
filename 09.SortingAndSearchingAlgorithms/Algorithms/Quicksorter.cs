namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            var currLeftIndex = leftIndex;
            var currRightIndex = rightIndex;
            var pivot = collection[(leftIndex + rightIndex) / 2];

            while (currLeftIndex <= currRightIndex)
            {
                while (collection[currLeftIndex].CompareTo(pivot) < 0)
                {
                    currLeftIndex++;
                }

                while (collection[currRightIndex].CompareTo(pivot) > 0)
                {
                    currRightIndex--;
                }

                if (currLeftIndex <= currRightIndex)
                {
                    T swap = collection[currLeftIndex];
                    collection[currLeftIndex] = collection[currRightIndex];
                    collection[currRightIndex] = swap;

                    currLeftIndex++;
                    currRightIndex--;
                }
            }

            if (currLeftIndex < rightIndex)
            {
                this.QuickSort(collection, currLeftIndex, rightIndex);
            }

            if (leftIndex < currRightIndex)
            {
                this.QuickSort(collection, leftIndex, currRightIndex);
            }
        }
    }
}
