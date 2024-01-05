using System.Text;

namespace NOJUMPO.Collections
{
    public class NJBinaryTreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public NJBinaryTreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public NJBinaryTreeNode<T> LeftChild { get { return _leftChild; } }
        public NJBinaryTreeNode<T> RightChild { get { return _rightChild; } }

        T _value;
        NJBinaryTreeNode<T> _parent;
        NJBinaryTreeNode<T> _leftChild;
        NJBinaryTreeNode<T> _rightChild;


        // ----------------------------- CONSTRUCTORS ------------------------------
        public NJBinaryTreeNode(T value, NJBinaryTreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _leftChild = null;
            _rightChild = null;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddChild(NJBinaryTreeNode<T> childToAdd, NJTreeNodeChildSide njTreeNodeChildSide) {
            if (njTreeNodeChildSide == NJTreeNodeChildSide.LEFT && _leftChild != null ||
                njTreeNodeChildSide == NJTreeNodeChildSide.RIGHT && _rightChild != null)
            {
                return false;
            }

            if (njTreeNodeChildSide == NJTreeNodeChildSide.LEFT)
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

        public bool RemoveChild(NJBinaryTreeNode<T> childToRemove) {
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
    }
}