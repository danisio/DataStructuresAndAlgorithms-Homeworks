namespace ImplementHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int DefaultCapacity = 16;
        private const float ResizeCoeff = 0.75f;

        private readonly HashSet<K> listOfKeys;
        private LinkedList<KeyValuePair<K, V>>[] elements;

        private int counter;
        private int capacity;

        public HashTable()
        {
            this.Clear();
            this.listOfKeys = new HashSet<K>();
        }

        public int Count
        {
            get
            {
                return this.counter;
            }
        }

        public K[] Keys
        {
            get
            {
                foreach (var item in this)
                {
                    this.listOfKeys.Add(item.Key);
                }

                return this.listOfKeys.ToArray();
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
        }

        public void Add(K key, V value)
        {
            if (this.Contains(key))
            {
                return;
            }

            int index = this.GetIndex(key);

            if (this.elements[index] == null)
            {
                this.elements[index] = new LinkedList<KeyValuePair<K, V>>();
            }

            this.elements[index].AddFirst(new KeyValuePair<K, V>(key, value));
            this.counter++;

            if (this.counter > ResizeCoeff * this.capacity)
            {
                this.ResizeHashTable();
            }
        }

        public V Find(K key)
        {
            var index = this.GetIndex(key);

            if (this.elements[index] == null)
            {
                return default(V);
            }

            var result = this.elements[index];

            foreach (var item in result)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }

        public void Remove(K key)
        {
            if (!this.Contains(key))
            {
                throw new InvalidOperationException("Key not found.");
            }

            var index = this.GetIndex(key);

            var valueToRemove = this.elements[index].First(p => p.Key.Equals(key));
            this.elements[index].Remove(valueToRemove);
            this.counter--;

            if (this.elements[index].Count == 0)
            {
                this.elements[index] = null;
            }
        }

        public void Clear()
        {
            this.counter = 0;
            this.capacity = DefaultCapacity;
            this.elements = new LinkedList<KeyValuePair<K, V>>[this.capacity];
        }

        public bool Contains(K key)
        {
            var index = this.GetIndex(key);

            if (this.elements[index] == null)
            {
                return false;
            }

            var result = this.elements[index];

            foreach (var item in result)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valuesList in this.elements)
            {
                if (valuesList == null)
                {
                    continue;
                }

                foreach (var item in valuesList)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }

        private void ResizeHashTable()
        {
            var oldvalues = (LinkedList<KeyValuePair<K, V>>[])this.elements.Clone();
            this.elements = new LinkedList<KeyValuePair<K, V>>[this.capacity * 2];
            this.counter = 0;

            foreach (var item in oldvalues)
            {
                foreach (var value in item)
                {
                    this.Add(value.Key, value.Value);
                }
            }
        }
    }
}
