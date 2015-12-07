namespace ImplementBiDictionary
{
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private readonly MultiDictionary<K1, T> dict1;
        private readonly MultiDictionary<K2, T> dict2;

        public BiDictionary()
        {
            this.dict1 = new MultiDictionary<K1, T>(true);
            this.dict2 = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T element)
        {
            this.dict1.Add(key1, element);
            this.dict2.Add(key2, element);
        }

        public T[] FindByFirstKey(K1 key1)
        {
            return this.dict1[key1].ToArray();
        }

        public T[] FindBySecondKey(K2 key2)
        {
            return this.dict2[key2].ToArray();
        }

        public T[] FindByBothKeys(K1 key1, K2 key2)
        {
            var result = FindByFirstKey(key1).Intersect(FindBySecondKey(key2));
            return result.ToArray();
        }
    }
}
