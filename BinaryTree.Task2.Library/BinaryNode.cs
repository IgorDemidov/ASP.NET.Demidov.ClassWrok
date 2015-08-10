using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Task2.Library
{
    class BinaryNode<T>
    {
        private T data;
        private BinaryNode<T> left;
        private BinaryNode<T> right;
        private BinaryNode<T> parent;

        public T Data 
        {
            get { return data; }
            set { data = value; }
        }

        public BinaryNode() { }
        public BinaryNode(BinaryNode<T> parent, T data, BinaryNode<T> left, BinaryNode<T> right)//main ctor
        {
            this.data = data;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
        public BinaryNode(BinaryNode<T> parent, T data)
            : this(parent, data, null, null) { }

        public BinaryNode<T> Left 
        {
            get { return left; }
            set { left = value; } 
        }

        public BinaryNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public BinaryNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }




    }
}
