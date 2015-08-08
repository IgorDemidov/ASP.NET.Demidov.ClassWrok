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
            keys = new List<TKey>();
            values = new List<TValue>();
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

            if (IsNeedsExpanding())
                Expand();

            AddToTable(key, value);

            count++;
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null", "key");

            if (segments.Length == 0)
                return false;

            Segment suitable = segments[GetSegmentNumber(key)];
            if (suitable == null)
                return false;

            foreach (int index in suitable.Indexes)
            {
                if (keys[index].Equals(key))
                    return true;
            }
            return false;
        }

        public TValue GetValue(TKey key)
        {
            if (!Contains(key))
                throw new ArgumentException("Current hashtable does not contain this key");

            Segment suitable = segments[GetSegmentNumber(key)];
            int index = 0;
            while (true)
            {
                if (keys[index].Equals(key))
                {
                    return values[index];
                }
                index++;
            }
        }

        public void Clear()
        {
            count = 0;
            capacity = 0;
            keys = new List<TKey>();
            values = new List<TValue>();
            segments = new Segment[count];
        }

        #region Private Methods

        private int GetSegmentNumber(TKey key)
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

        private void AddToTable(TKey key, TValue value)
        {
            keys.Add(key);
            values.Add(value);
            segments[GetSegmentNumber(key)].AddIndex(count - 1);
        }

        private void Expand()
        {
            if (capacity == 0)
                capacity = 1;
            else 
                capacity *= 2;

            segments = new Segment[capacity];
            RebuildTable();
        }

        private void RebuildTable()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                Add(keys[i], values[i]);
            }
        }

        #endregion
       

        

        


       
    }
}
