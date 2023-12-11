using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class Tree<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public TreeNode<T> Root { get { return _root; } }
        public int Count { get { return _nodes.Count; } }

        TreeNode<T> _root = null;
        List<TreeNode<T>> _nodes = new List<TreeNode<T>>();

        // ----------------------------- CONSTRUCTORS ------------------------------
        public Tree(T value) {
            _root = new TreeNode<T>(value, null);
            _nodes.Add(_root);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}