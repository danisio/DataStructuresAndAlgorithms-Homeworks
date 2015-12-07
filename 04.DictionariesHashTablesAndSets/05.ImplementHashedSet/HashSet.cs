namespace ImplementHashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ImplementHashTable;

    public class HashSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> values;
        private int count;

        public HashSet()
        {
            this.Clear();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.values = new HashTable<int, T>();
        }

        public void Add(T value)
        {
            int key = this.GetHashCode(value);
            this.values.Add(key, value);
            this.count++;
        }

        public T Find(T value)
        {
            int key = this.GetHashCode(value);
            return this.values[key];
        }

        public void Remove(T value)
        {
            int key = this.GetHashCode(value);
            this.values.Remove(key);
            this.count--;
        }

        public HashSet<T> Intersect(HashSet<T> other)
        {
            var result = new HashSet<T>();

            foreach (var item in this.values)
            {
                foreach (var otherItem in other.values)
                {
                    if (item.Key == otherItem.Key)
                    {
                        result.Add(item.Value);
                    }
                }
            }

            return result;
        }

        public HashSet<T> Union(HashSet<T> other)
        {
            var result = new HashSet<T>();

            foreach (var item in this.values)
            {
                result.Add(item.Value);
            }

            foreach (var item in other.values)
            {
                if (!result.values.Contains(item.Key))
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.values)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHashCode(T value)
        {
            return Math.Abs(value.GetHashCode() % this.values.Count);
        }
    }
}
