using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Task3.Library
{
    public class CustomHashTable<TKey, TValue>
    {
        private Segment[] segments;
        private List<TKey> keys;
        private List<TValue> values;
        private int capacity;
        private int count;

        public CustomHashTable() : this(0) { }
        public CustomHashTable(int capacity)   //main ctor
        {
            segments = new Segment[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            if (this.Contains(key))
                throw new InvalidOperationException("This key is exist in current HashTable");
            
            
        }

        private int GetIndex(TKey key)
        {
            return key.GetHashCode() % capacity;
        }

        public bool Contains(TKey key)
        {
            Segment suitable = segments[GetIndex(key)];
            if (suitable == null)
                return false;

            foreach (int index in suitable.indexes)
            {
                if (key.Equals(keys[index]))
                    return true;
            }
            return false;
        }

        

        


       
    }
}
