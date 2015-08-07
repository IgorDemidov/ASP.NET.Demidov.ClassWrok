using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Task3.Library
{
    public class CustomHashTable<TKey, TValue>
    {
        private object[] indexes;
        private List<TKey> keys;
        private List<List<TValue>> values;
        private float loadFactor = 1.0f;
        private int capacity = 0;
        private int count;

        public CustomHashTable() : this(0, 1.0f) { }
        public CustomHashTable(int capacity) : this(capacity, 1.0f) { }
        public CustomHashTable(int capacity, float loadFactor) //main ctor
        {
            indexes = new object[capacity];
        }

        public int GetIndex(TKey key)
        {
            int index;
            unchecked
            {
                int hash = key.GetHashCode();
                index = Math.Abs(hash % (int.MaxValue));
            }
            return index;
        }

        public void Add(TKey key, TValue value)
        {
            if ((key==null)||(value ==null))
                throw new ArgumentNullException("Key or/and value cannot be null");

            int index = GetIndex(key);
            if (index > capacity-1)

            keys.Add(key);
        ///    values.Add();
        }

    }
}
