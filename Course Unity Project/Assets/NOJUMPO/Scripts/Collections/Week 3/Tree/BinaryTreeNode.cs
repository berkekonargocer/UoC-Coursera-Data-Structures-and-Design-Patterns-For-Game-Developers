using System.Collections.Generic;
using System.Text;

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

        public bool RemoveBothChildren() {
            if (_leftChild != null)
            {
                _leftChild.Parent = null;
                _leftChild = null;
            }

            if (_rightChild != null)
            {
                _rightChild.Parent = null;
                _rightChild = null;
            }

            return true;
        }

        public override string ToString() {
            StringBuilder binaryTreeNode = new StringBuilder();
            binaryTreeNode.Append($"[Node Value: {_value} Parent Value: ");

            binaryTreeNode.Append(_parent != null ? $"{_parent.Value} " : "null ");

            binaryTreeNode.Append("Left Child Value: ");
            binaryTreeNode.Append(_leftChild != null ? $"{_leftChild.Value} " : "null ");

            binaryTreeNode.Append("Right Child Value: ");
            binaryTreeNode.Append(_rightChild != null ? $"{_rightChild.Value} " : "null ");

            binaryTreeNode.Append("]");

            return binaryTreeNode.ToString();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}