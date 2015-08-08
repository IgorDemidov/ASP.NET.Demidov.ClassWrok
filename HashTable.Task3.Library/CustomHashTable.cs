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
        private readonly double loadFactor = 1.0;

        #region Constructors

        public CustomHashTable() : this(0) { }

        public CustomHashTable(int capacity)   //main ctor
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity cannot be negative", "capacity");

            segments = new Segment[capacity];
        }
       
        public CustomHashTable(int capacity, double loadFactor)
            : this(capacity)
        {
            if ((loadFactor < 0.1) || (loadFactor > 1.0))
                throw new ArgumentOutOfRangeException("LoadFactor should be in the range from 0.1 through 1.0","loadFactor");

            this.loadFactor = loadFactor;
        }

        #endregion
        
        public void Add(TKey key, TValue value)
        {
            if (this.Contains(key))
                throw new InvalidOperationException("This key is already exist in current hashtable");


            count++;
        }

        

        public bool Contains(TKey key)
        {
            if (segments.Length == 0)
                return false;

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

        #region Private Methods

        private int GetIndex(TKey key)
        {
            return key.GetHashCode() % capacity;
        }

        private bool IsNeedsExpanding()
        {
            if (capacity == 0)
                return true;

            double actualLoadFactor = count / capacity;
            if (actualLoadFactor >= loadFactor)
                return true;
            else
                return false;
        }

        #endregion
       

        

        


       
    }
}
