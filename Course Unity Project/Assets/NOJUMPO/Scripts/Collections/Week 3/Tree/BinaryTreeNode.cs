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
        public bool AddChild(BinaryTreeNode<T> childToAdd, ChildSide childSide) {
            if (_leftChild == childToAdd || _rightChild == childToAdd)
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
                _leftChild = childToAdd;
            }
            else
            {
                _rightChild = childToAdd;
            }
            
            childToAdd.Parent = this;
            return true;
        }

        public bool RemoveChild(BinaryTreeNode<T> childToRemove) {
            if (_leftChild == childToRemove)
            {
                _leftChild.Parent = null;
                _leftChild = null;
                return true;
            }

            if (_rightChild == childToRemove)
            {
                _rightChild.Parent = null;
                _rightChild = null;
            }
            
            return false;
        }
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}