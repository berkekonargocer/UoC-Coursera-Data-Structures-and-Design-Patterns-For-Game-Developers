using NOJUMPO.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public class MinimaxTreeTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        static List<int> binContents = new List<int>();
        static List<BinHolder> binHolders = new List<BinHolder>();


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            int[] bins = { 1, 2 };

            MinimaxTree<BinHolder> minimaxTree = BuildTree(bins);
            Minimax(minimaxTree.Root, true);

            IList<MinimaxTreeNode<BinHolder>> children = minimaxTree.Root.Children;
            MinimaxTreeNode<BinHolder> maxChildNode = children[0];

            for (int i = 1; i < children.Count; i++)
            {
                if (children[i].MinimaxScore > maxChildNode.MinimaxScore)
                {
                    maxChildNode = children[i];
                }
            }

            Debug.Log($"Best move is: {maxChildNode.Value}");
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        MinimaxTree<BinHolder> BuildTree(int[] binItems) {
            binContents.Clear();

            for (int i = 0; i < binItems.Length; i++)
            {
                binContents.Add(binItems[i]);
            }

            BinHolder binHolder = new BinHolder(binContents);

            MinimaxTree<BinHolder> tree = new MinimaxTree<BinHolder>(binHolder);

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

        List<BinHolder> GetNextBinHolder(BinHolder currentBinHolder) {
            binHolders.Clear();
            IList<int> currentBins = currentBinHolder.Bins;

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

        void Minimax(MinimaxTreeNode<BinHolder> node, bool isMaximizing) {
            IList<MinimaxTreeNode<BinHolder>> children = node.Children;

            if (children.Count > 0)
            {
                foreach (MinimaxTreeNode<BinHolder> childNode in children)
                {
                    Minimax(childNode, !isMaximizing);
                }

                if (isMaximizing)
                {
                    node.MinimaxScore = int.MinValue;
                }
                else
                {
                    node.MinimaxScore = int.MaxValue;
                }


                foreach (MinimaxTreeNode<BinHolder> childNode in children)
                {
                    if (isMaximizing)
                    {
                        if (childNode.MinimaxScore > node.MinimaxScore)
                        {
                            node.MinimaxScore = childNode.MinimaxScore;
                        }
                    }
                    else
                    {
                        if (childNode.MinimaxScore < node.MinimaxScore)
                        {
                            node.MinimaxScore = childNode.MinimaxScore;
                        }
                    }
                }
            }
            else
            {
                AssignMinimaxScore(node, isMaximizing);
            }
        }

        void AssignMinimaxScore(MinimaxTreeNode<BinHolder> node, bool isMaximizing) {
            if (node.Value.IsEmpty)
            {
                if (isMaximizing)
                {
                    node.MinimaxScore = 1;
                }
                else
                {
                    node.MinimaxScore = 0;
                }
            }
        }
    }
}