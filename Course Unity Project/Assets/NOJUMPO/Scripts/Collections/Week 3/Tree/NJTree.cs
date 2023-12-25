using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class NJTree<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public NJTreeNode<T> Root { get { return _root; } }
        public int Count { get { return _nodes.Count; } }

        NJTreeNode<T> _root = null;
        List<NJTreeNode<T>> _nodes = new List<NJTreeNode<T>>();

        // ----------------------------- CONSTRUCTORS ------------------------------
        public NJTree(T value) {
            _root = new NJTreeNode<T>(value, null);
            _nodes.Add(_root);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

        // O(n)
        public NJTreeNode<T> Find(T value) {
            foreach (NJTreeNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        // O(n)
        public bool AddNode(NJTreeNode<T> nodeToAdd) {
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

        // O(n²)
        public bool RemoveNode(NJTreeNode<T> nodeToRemove) {
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

            IList<NJTreeNode<T>> children = nodeToRemove.Children;

            for (int i = children.Count - 1; i >= 0; i--)
            {
                RemoveNode(children[i]);
            }

            return true;
        }

        // O(n)
        public override string ToString() {
            StringBuilder treeStringBuilder = new StringBuilder();

            treeStringBuilder.Append("Root: ");

            if (_root == null)
            {
                treeStringBuilder.Append("null ");
                return treeStringBuilder.ToString();
            }

            treeStringBuilder.Append($"{_root} \n Nodes: ");

            for (int i = 0; i < Count; i++)
            {
                treeStringBuilder.Append($"{_nodes[i]}");

                if (i < Count - 1)
                {
                    treeStringBuilder.Append(", ");
                }
            }

            return treeStringBuilder.ToString();
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------

        // O(n)
        void Clear() {
            foreach (NJTreeNode<T> node in _nodes)
            {
                node.Parent = null;
                node.RemoveAllChildren();
            }

            for (int i = 0; i < Count; i++)
            {
                _nodes.RemoveAt(i);
            }

            _root = null;
        }
    }
}