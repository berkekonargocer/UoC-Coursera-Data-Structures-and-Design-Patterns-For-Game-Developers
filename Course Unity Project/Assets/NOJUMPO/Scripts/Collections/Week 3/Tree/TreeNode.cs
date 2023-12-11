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


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}