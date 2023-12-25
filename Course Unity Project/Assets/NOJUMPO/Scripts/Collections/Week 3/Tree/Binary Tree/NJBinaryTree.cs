using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class NJBinaryTree<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public NJBinaryTreeNode<T> Root { get { return _root; } }
        public int Count { get { return _nodes.Count; } }

        NJBinaryTreeNode<T> _root = null;
        List<NJBinaryTreeNode<T>> _nodes = new List<NJBinaryTreeNode<T>>();

        // ----------------------------- CONSTRUCTORS ------------------------------
        public NJBinaryTree(T value) {
            _root = new NJBinaryTreeNode<T>(value, null);
            _nodes.Add(_root);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public NJBinaryTreeNode<T> Find(T value) {
            foreach (NJBinaryTreeNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        public bool AddNode(NJBinaryTreeNode<T> nodeToAdd, ChildSide childSide) {
            if (nodeToAdd?.Parent == null || !_nodes.Contains(nodeToAdd.Parent))
            {
                return false;
            }

            if (nodeToAdd.Parent.LeftChild == nodeToAdd || nodeToAdd.Parent.RightChild == nodeToAdd)
            {
                return false;
            }

            _nodes.Add(nodeToAdd);
            return nodeToAdd.Parent.AddChild(nodeToAdd, childSide);
        }

        public bool RemoveNode(NJBinaryTreeNode<T> nodeToRemove) {
            if (nodeToRemove == null)
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

            if (nodeToRemove.LeftChild != null)
            {
                RemoveNode(nodeToRemove.LeftChild);
            }

            if (nodeToRemove.RightChild != null)
            {
                RemoveNode(nodeToRemove.RightChild);
            }

            return true;
        }

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
        void Clear() {
            foreach (NJBinaryTreeNode<T> node in _nodes)
            {
                node.Parent = null;
                node.RemoveBothChildren();
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _nodes.RemoveAt(i);
            }

            _root = null;
        }
    }
}