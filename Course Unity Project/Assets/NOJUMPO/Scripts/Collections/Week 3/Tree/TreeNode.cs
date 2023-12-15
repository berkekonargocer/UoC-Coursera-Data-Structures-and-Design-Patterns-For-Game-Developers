using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class TreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public TreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public IList<TreeNode<T>> Children { get { return _children.AsReadOnly(); } }

        T _value;
        TreeNode<T> _parent;
        List<TreeNode<T>> _children;

        // ----------------------------- CONSTRUCTORS ------------------------------
        public TreeNode(T value, TreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _children = new List<TreeNode<T>>();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        
        // O(n)
        public bool AddChild(TreeNode<T> child) {
            if (_children.Contains(child))
            {
                return false;
            }

            if (child == this)
            {
                return false;
            }

            child.Parent = this;
            _children.Add(child);
            return true;
        }

        // O(n)
        public virtual bool RemoveChild(TreeNode<T> child) {
            if (!_children.Contains(child))
                return false;

            child.Parent = null;
            return _children.Remove(child);
        }

        // O(n)
        public bool RemoveAllChildren() {
            for (int i = _children.Count; i >= 0; i--)
            {
                _children[i].Parent = null;
                _children.RemoveAt(i);
            }

            return true;
        }

        // O(n)
        public override string ToString() {
            StringBuilder treeNodeString = new StringBuilder();

            treeNodeString.Append($"[Node Value: {_value} Parent Value: ");

            if (_parent != null)
            {
                treeNodeString.Append($"{_parent._value} ");
            }
            else
            {
                treeNodeString.Append("null ");
            }

            treeNodeString.Append("Children Values: ");

            for (int i = 0; i < _children.Count; i++)
            {
                treeNodeString.Append($"{_children[i].Value}");

                if (i < _children.Count - 1)
                {
                    treeNodeString.Append(", ");
                }
            }

            treeNodeString.Append("]");

            return treeNodeString.ToString();
        }
    }
}