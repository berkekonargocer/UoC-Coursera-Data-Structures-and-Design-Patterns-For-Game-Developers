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


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
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

        public bool RemoveChild(TreeNode<T> child) {
            if (_children.Contains(child))
            {
                child.Parent = null;
                return _children.Remove(child);
            }

            return false;
        }

        public bool RemoveAllChildren() {
            for (int i = _children.Count; i >= 0 ; i--)
            {
                _children[i].Parent = null;
                _children.RemoveAt(i);
            }

            return true;
        }

        public override string ToString() {
            StringBuilder treeNodeString = new StringBuilder();
            
            treeNodeString.Append($"[Node Value: {_value} Parent Value: ");

            if (_parent != null)
            {
                treeNodeString.Append($"{_parent._value}");
            }
            else
            {
                treeNodeString.Append("null");
            }

            treeNodeString.Append("Children Values: ");

            for (int i = 0; i < _children.Count; i++)
            {
                treeNodeString.Append($"{_children[i]._value }");
            }

            treeNodeString.Append("]");

            return treeNodeString.ToString();
        }
    }
}