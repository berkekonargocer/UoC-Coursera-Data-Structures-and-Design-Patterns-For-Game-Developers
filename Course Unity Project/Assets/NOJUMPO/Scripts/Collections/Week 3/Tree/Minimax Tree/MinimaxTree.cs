using System.Collections.Generic;
using System.Text;

namespace NOJUMPO.Collections
{
    public class MinimaxTree<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public MinimaxTreeNode<T> TreeNode { get; set; }
        public MinimaxTreeNode<T> Root { get { return _root; } }

        public int Count { get { return _nodes.Count; } }

        MinimaxTreeNode<T> _root = null;
        List<MinimaxTreeNode<T>> _nodes = new List<MinimaxTreeNode<T>>();

        static List<int> binContents = new List<int>();
        static List<MinimaxConfiguration> newConfiguration = new List<MinimaxConfiguration>();


        // ----------------------------- CONSTRUCTORS ------------------------------
        public MinimaxTree(T value) {
            _root = new MinimaxTreeNode<T>(value, null);
            _nodes.Add(_root);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

        // O(n)
        public MinimaxTreeNode<T> Find(T value) {
            foreach (MinimaxTreeNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        // O(n)
        public bool AddNode(MinimaxTreeNode<T> nodeToAdd) {
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
        public bool RemoveNode(MinimaxTreeNode<T> nodeToRemove) {
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

            IList<MinimaxTreeNode<T>> children = nodeToRemove.Children;

            for (int i = children.Count - 1; i >= 0; i--)
            {
                RemoveNode(children[i]);
            }

            return true;
        }

        public MinimaxTree<MinimaxConfiguration> BuildTree(int[] binItems) {
            binContents.Clear();

            for (int i = 0; i < binItems.Length; i++)
            {
                binContents.Add(binItems[i]);
            }

            MinimaxConfiguration rootConfiguration = new MinimaxConfiguration(binContents);

            MinimaxTree<MinimaxConfiguration> tree = new MinimaxTree<MinimaxConfiguration>(rootConfiguration);

            LinkedList<MinimaxTreeNode<MinimaxConfiguration>> nodeList = new LinkedList<MinimaxTreeNode<MinimaxConfiguration>>();

            nodeList.AddLast(tree.Root);

            while (nodeList.Count > 0)
            {
                MinimaxTreeNode<MinimaxConfiguration> currentNode = nodeList.First.Value;

                nodeList.RemoveFirst();

                List<MinimaxConfiguration> children = GetNextConfiguration(currentNode.Value);

                foreach (MinimaxConfiguration child in children)
                {
                    MinimaxTreeNode<MinimaxConfiguration> childNode = new MinimaxTreeNode<MinimaxConfiguration>(child, currentNode);
                    tree.AddNode(childNode);
                    nodeList.AddLast(childNode);
                }
            }

            return tree;
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
        List<MinimaxConfiguration> GetNextConfiguration(MinimaxConfiguration currentConfiguration) {
            newConfiguration.Clear();
            IList<int> currentBins = currentConfiguration.Bins;

            for (int i = 0; i < currentBins.Count; i++)
            {
                int currentBinCount = currentBins[i];
                while (currentBinCount > 0)
                {
                    currentBinCount--;

                    binContents.Clear();
                    binContents.AddRange(currentBins);
                    binContents[i] = currentBinCount;

                    newConfiguration.Add(new MinimaxConfiguration(binContents));
                }
            }

            return newConfiguration;
        }

        // O(n)
        void Clear() {
            foreach (MinimaxTreeNode<T> node in _nodes)
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