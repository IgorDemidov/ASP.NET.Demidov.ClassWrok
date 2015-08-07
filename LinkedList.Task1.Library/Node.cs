using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Task1.Library
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }

        public Node() { }
        public Node(T data)
        {
            this.Data = data;
        }

    }
}
