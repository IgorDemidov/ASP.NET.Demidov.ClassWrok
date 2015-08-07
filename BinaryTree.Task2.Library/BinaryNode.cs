using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Task2.Library
{
    public class BinaryNode<T>
    {
        private T data;
        private BinaryNode<T> left;
        private BinaryNode<T> right;

        public T Data 
        {
            get { return data; }
            set { data = value; }
        }

        public BinaryNode() { }
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

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




    }
}
