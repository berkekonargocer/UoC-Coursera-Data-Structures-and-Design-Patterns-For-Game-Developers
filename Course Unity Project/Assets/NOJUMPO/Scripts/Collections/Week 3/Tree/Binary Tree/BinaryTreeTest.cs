using System;
using Nojumpo.Collections;
using UnityEngine;

namespace Nojumpo
{
    public class BinaryTreeTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        BinaryTree<char> _binaryTree;

        // ----------------------------- CONSTRUCTORS ------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _binaryTree = BuildBinaryTree();
        }

        void Start() {
            Debug.Log($"{_binaryTree}");
            PreOrderTraversal(_binaryTree.Root);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        BinaryTree<char> BuildBinaryTree() {
            BinaryTree<char> tree = new BinaryTree<char>('A');

            BinaryTreeNode<char> nodeB = new BinaryTreeNode<char>('B', tree.Root);
            BinaryTreeNode<char> nodeC = new BinaryTreeNode<char>('C', tree.Root);
            BinaryTreeNode<char> nodeD = new BinaryTreeNode<char>('D', nodeB);
            BinaryTreeNode<char> nodeE = new BinaryTreeNode<char>('E', nodeB);
            BinaryTreeNode<char> nodeF = new BinaryTreeNode<char>('F', nodeE);
            BinaryTreeNode<char> nodeG = new BinaryTreeNode<char>('G', nodeE);
            BinaryTreeNode<char> nodeH = new BinaryTreeNode<char>('H', nodeC);
            BinaryTreeNode<char> nodeI = new BinaryTreeNode<char>('I', nodeH);

            tree.AddNode(nodeB, ChildSide.LEFT);
            tree.AddNode(nodeC, ChildSide.RIGHT);
            tree.AddNode(nodeD, ChildSide.LEFT);
            tree.AddNode(nodeE, ChildSide.RIGHT);
            tree.AddNode(nodeF, ChildSide.LEFT);
            tree.AddNode(nodeG, ChildSide.RIGHT);
            tree.AddNode(nodeH, ChildSide.RIGHT);
            tree.AddNode(nodeI, ChildSide.LEFT);

            return tree;
        }

        void PreOrderTraversal(BinaryTreeNode<char> node) {
            if (node == null)
                return;
            
            Debug.Log($"{node.Value} ");

            if (node.LeftChild != null)
            {
                PreOrderTraversal(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                PreOrderTraversal(node.RightChild);
            }
        }
        
        void InOrderTraversal(BinaryTreeNode<char> node) {
            if (node == null)
                return;

            if (node.LeftChild != null)
            {
                PreOrderTraversal(node.LeftChild);
            }
            
            Debug.Log($"{node.Value} ");
            
            if (node.RightChild != null)
            {
                PreOrderTraversal(node.RightChild);
            }
        }
        
    }
}