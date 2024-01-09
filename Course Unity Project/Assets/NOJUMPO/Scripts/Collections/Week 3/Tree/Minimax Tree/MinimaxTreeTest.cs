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
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        MinimaxTree<BinHolder> BuildTree(int[] binItems) {
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
                // Assign Minimax Score
            }
        }
    }
}