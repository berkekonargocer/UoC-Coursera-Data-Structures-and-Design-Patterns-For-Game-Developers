using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class BinaryTreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public BinaryTreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public BinaryTreeNode<T> LeftChild { get { return leftChild; } }
        public BinaryTreeNode<T> RightChild { get { return rightChild; } }
        public IList<BinaryTreeNode<T>> Children { get { return _children.AsReadOnly(); } }

        T _value;
        BinaryTreeNode<T> _parent;
        BinaryTreeNode<T> leftChild;
        BinaryTreeNode<T> rightChild;
        List<BinaryTreeNode<T>> _children;
        
        
        // ----------------------------- CONSTRUCTORS ------------------------------
        public BinaryTreeNode(T value, BinaryTreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _children = new List<BinaryTreeNode<T>>();
            leftChild = null;
            rightChild = null;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddChild(BinaryTreeNode<T> child, ChildSide childSide) {
            if (leftChild == child || rightChild == child)
            {
                return false;
            }

            if (childSide == ChildSide.LEFT && leftChild != null || 
                childSide == ChildSide.RIGHT && rightChild != null)
            {
                return false;
            }

            child.Parent = this;
            _children.Add(child);
            return true;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}