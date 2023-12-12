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
        public bool AddNode(TreeNode<T> nodeToAdd) {
            if (nodeToAdd?.Parent == null || !_nodes.Contains(nodeToAdd.Parent))
            {
                return false;
            }

            if (nodeToAdd.Parent.Children.Contains(nodeToAdd))
            {
                return false;
            }

            _nodes.Add(nodeToAdd);
            return nodeToAdd.Parent.AddChild(nodeToAdd);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}