using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class BinaryTreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public BinaryTreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public BinaryTreeNode<T> LeftChild { get { return _leftChild; } }
        public BinaryTreeNode<T> RightChild { get { return _rightChild; } }
        public IList<BinaryTreeNode<T>> Children { get { return _children.AsReadOnly(); } }

        T _value;
        BinaryTreeNode<T> _parent;
        BinaryTreeNode<T> _leftChild;
        BinaryTreeNode<T> _rightChild;
        List<BinaryTreeNode<T>> _children;
        
        
        // ----------------------------- CONSTRUCTORS ------------------------------
        public BinaryTreeNode(T value, BinaryTreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _children = new List<BinaryTreeNode<T>>();
            _leftChild = null;
            _rightChild = null;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddChild(BinaryTreeNode<T> child, ChildSide childSide) {
            if (_leftChild == child || _rightChild == child)
            {
                return false;
            }

            if (childSide == ChildSide.LEFT && _leftChild != null || 
                childSide == ChildSide.RIGHT && _rightChild != null)
            {
                return false;
            }

            if (childSide == ChildSide.LEFT)
            {
                _leftChild = child;
            }
            else
            {
                _rightChild = child;
            }
            
            child.Parent = this;
            return true;
        }
        
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}