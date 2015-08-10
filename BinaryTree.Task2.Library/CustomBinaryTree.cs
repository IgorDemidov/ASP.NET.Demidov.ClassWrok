using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Task2.Library
{
    public class BinaryTree<T> where T: IComparable<T>
    {
        #region PrivateFields

        private BinaryNode<T> root;
        private IComparer<T> comparer = Comparer<T>.Default;
        private int count = 0;

        #endregion

        #region Properties

        public int Count { get { return count; } }
        public T Min { get { return FindMinNode(root).Data; } }
        public T Max { get { return FindMaxNode(root).Data; } }

        #endregion

        #region Constructors

        public BinaryTree() { }
        public BinaryTree(IComparer<T> comparer) //main ctor
        {
            this.comparer = comparer;
        } 

        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer)
            : this(comparer)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        
        #endregion

        #region Public methods

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Data cannot be null", "data");

            if (root == null)
            {
                root = new BinaryNode<T>(null, data);
                return;
            }
            AddNode(root, data);
            count++;
        }

        public bool Remove(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Data cannot be null", "data");

            if (root == null)
                throw new NullReferenceException("Current binary tree is empty");

            BinaryNode<T> target = FindNodeByData(root, data);

            if (target == null)
                return false;

            if (target.Right == null)
            {
                if (target.Left != null)
                    target.Left.Parent = target.Parent;

                target = target.Left;
            }
            else
            {
                if (target.Left != null)
                {
                    BinaryNode<T> minRight = FindMinNode(target.Right);
                    target.Left.Parent = minRight;
                    minRight.Left = target.Left;
                }

                target.Right.Parent = target.Parent;
                target = target.Right;
            }
            count--;
            return true;
        }

        #endregion
        
        #region Private methods

        private void AddNode(BinaryNode<T> parent, T data)
        {
            switch (comparer.Compare(data, parent.Data))
            {
                case 1:
                    {
                        if (parent.Right == null)
                            parent.Right = new BinaryNode<T>(parent, data);
                        else
                            AddNode(parent.Right, data);
                        break;
                    }
                case -1:
                    {
                        if (parent.Left == null)
                            parent.Left = new BinaryNode<T>(parent, data);
                        else
                            AddNode(parent.Left, data);
                        break;
                    }
                default:
                    throw new ArgumentException("Data values should be an unequal");
            }
        }

        private BinaryNode<T> FindNodeByData(BinaryNode<T> currentRoot, T data)
        {
            BinaryNode<T> result = null;
            switch (comparer.Compare(data, currentRoot.Data))
            {
                case 1:
                    if (currentRoot.Right != null)
                        result = FindNodeByData(currentRoot.Right, data);
                    break;
                case -1:
                    if (currentRoot.Left != null)
                        result = FindNodeByData(currentRoot.Left, data);
                    break;
                case 0:
                    result = currentRoot;
                    break;
            }
            return result;
        }

        private BinaryNode<T> FindMinNode(BinaryNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;
            if (currentRoot.Left == null)
                return currentRoot.Left;
            return FindMinNode(currentRoot.Left);
        }

        private BinaryNode<T> FindMaxNode(BinaryNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;
            if (currentRoot.Right == null)
                return currentRoot.Right;
            return FindMinNode(currentRoot.Right);
        }

        #endregion

    }
}
