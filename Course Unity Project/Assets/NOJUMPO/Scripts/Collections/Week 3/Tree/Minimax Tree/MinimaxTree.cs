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
        static List<BinHolder> binHolders = new List<BinHolder>();


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

        // O(n�)
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

        public MinimaxTree<BinHolder> BuildTree(int[] binItems) {
            binContents.Clear();

            for (int i = 0; i < binItems.Length; i++)
            {
                binContents.Add(binItems[i]);
            }

            BinHolder rootConfiguration = new BinHolder(binContents);

            MinimaxTree<BinHolder> tree = new MinimaxTree<BinHolder>(rootConfiguration);

            LinkedList<MinimaxTreeNode<BinHolder>> nodeList = new LinkedList<MinimaxTreeNode<BinHolder>>();

            nodeList.AddLast(tree.Root);

            while (nodeList.Count > 0)
            {
                MinimaxTreeNode<BinHolder> currentNode = nodeList.First.Value;

                nodeList.RemoveFirst();

                List<BinHolder> children = GetNextBinHolder(currentNode.Value);

                foreach (BinHolder child in children)
                {
                    MinimaxTreeNode<BinHolder> childNode = new MinimaxTreeNode<BinHolder>(child, currentNode);
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
        List<BinHolder> GetNextBinHolder(BinHolder currentConfiguration) {
            binHolders.Clear();
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

                    binHolders.Add(new BinHolder(binContents));
                }
            }

            return binHolders;
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