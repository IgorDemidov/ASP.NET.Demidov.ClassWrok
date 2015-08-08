using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Task3.Library
{
    class Segment
    {
        private List<int> indexes = null;

        public List<int> Indexes { get { return indexes; } }

        public void AddIndex(int index)
        {
            if (indexes == null)
                indexes = new List<int>();
            indexes.Add(index);
        }
    }
}
