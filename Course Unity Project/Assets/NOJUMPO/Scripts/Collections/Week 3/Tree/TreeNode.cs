using System.Collections.Generic;

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

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}