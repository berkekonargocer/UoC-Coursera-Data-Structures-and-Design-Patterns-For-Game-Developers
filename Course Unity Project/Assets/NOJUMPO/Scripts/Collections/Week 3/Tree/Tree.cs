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

        public bool RemoveNode(TreeNode<T> nodeToRemove) {
            if (nodeToRemove == null || !_nodes.Contains(nodeToRemove))
            {
                return false;
            }

            if (nodeToRemove == _root)
            {
                Clear();
                return true;
            }

            bool removeFromParent = nodeToRemove.Parent.RemoveChild(nodeToRemove);

            if (!removeFromParent)
            {
                return false;
            }

            bool removeFromTree = _nodes.Remove(nodeToRemove);

            if (!removeFromTree)
            {
                return false;
            }

            if (nodeToRemove.Children.Count <= 0)
                return true;

            IList<TreeNode<T>> children = nodeToRemove.Children;

            for (int i = children.Count - 1; i >= 0; i--)
            {
                RemoveNode(children[i]);
            }

            return true;
        }

        public void Clear() {
            foreach (TreeNode<T> node in _nodes)
            {
                node.Parent = null;
                node.RemoveAllChildren();
            }

            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes.RemoveAt(i);
            }

            _root = null;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}