namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] temp;

        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            this.temp = new T[collection.Count];
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int middleIndex = (leftIndex + rightIndex) / 2;

            this.MergeSort(collection, leftIndex, middleIndex);
            this.MergeSort(collection, middleIndex + 1, rightIndex);

            this.Merge(collection, leftIndex, middleIndex, rightIndex);
        }

        private void Merge(IList<T> collection, int leftIndex, int middleIndex, int rightIndex)
        {
            int tempPointer = leftIndex;
            int leftPointer = leftIndex;
            int rightPointer = middleIndex + 1;

            while (leftPointer <= middleIndex && rightPointer <= rightIndex)
            {
                if (collection[leftPointer].CompareTo(collection[rightPointer]) < 0)
                {
                    this.temp[tempPointer++] = collection[leftPointer++];
                }
                else
                {
                    this.temp[tempPointer++] = collection[rightPointer++];
                }
            }

            while (leftPointer <= middleIndex)
            {
                this.temp[tempPointer++] = collection[leftPointer++];
            }

            while (rightPointer <= rightIndex)
            {
                this.temp[tempPointer++] = collection[rightPointer++];
            }

            for (int index = leftIndex; index <= rightIndex; index++)
            {
                collection[index] = this.temp[index];
            }
        }
    }
}