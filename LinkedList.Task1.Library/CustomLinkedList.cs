using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Task1.Library
{
    public class CustomLinkedList<T>
    {
        private Node<T> root;
        private int count = 0;

        public int Count { get { return count; } }

        public T First { get { return GetFirstLink().Data; } }

        public T Last { get { return root.Data; } }

        public CustomLinkedList()
        {
        }

        public CustomLinkedList(IEnumerable<T> collection): this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T data)
        {
            if (root==null)
                AddFirst(data);
            else
            {
                root.Next = new Node<T>(data);
                root.Next.Prev = root;
                root = root.Next; 
            }
            count++;
        }

        public bool Contains(T data)
        {
            if (root == null)
                throw new ArgumentNullException();

            foreach (var item in this)
            {
                if (item.Equals(data))
                {
                    return true; 
                }
            }
            return false;
        }

        public void Remove(T data)
        {
            if (root == null)
                throw new ArgumentNullException();
            Node<T> currNode = root;
            for (int i = 1; i <= Count; i++)
            {
                if (currNode.Data.Equals(data))
                    break;
                currNode = currNode.Prev;
            }
            if (currNode!=null)
            {
                Node<T> prev;
                Node<T> next;
                prev = currNode.Prev;
                next = currNode.Next;
                if (prev!=null)
                    prev.Next = next;
                if (next != null)
                    next.Prev = prev;
            }


        }

        private void AddFirst(T data)
        {
            root = new Node<T>(data);
        }

        private Node<T> GetFirstLink()
        {
            Node<T> first = root;
            while (first.Prev!=null)
            {
                first = first.Prev;
            }
            return first;
        }

        public CustomEnumerator GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        public  class CustomEnumerator: IEnumerator<T>
        {
            CustomLinkedList<T> list;
            int position;
            Node<T> currNode;
            

            public CustomEnumerator(CustomLinkedList<T> list)
            {
                this.list = list;
                Reset();
            }

            public T Current
            {
                get 
                {
                    var result = currNode.Data;
                    currNode = currNode.Next;
                    return result;
                }
            }

            public void Dispose()
            {
                Reset();
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                if (position <= list.Count)
                {
                    position++;
                    return true;
                }                    
                else
                    return false;
            }

            public void Reset()
            {
                position = 0;
                currNode = list.GetFirstLink();
            }
        }

    }
}
