using System.Collections.Generic;
using Nojumpo.Collections;
using UnityEngine;

namespace Nojumpo
{
    public class BinaryTreeTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        NJBinaryTree<char> _njBinaryTree;

        // ----------------------------- CONSTRUCTORS ------------------------------


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _njBinaryTree = BuildBinaryTree();
        }

        void Start() {
            Debug.Log($"{_njBinaryTree}");
            PreOrderTraversal(_njBinaryTree.Root);
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        NJBinaryTree<char> BuildBinaryTree() {
            NJBinaryTree<char> tree = new NJBinaryTree<char>('A');

            NJBinaryTreeNode<char> nodeB = new NJBinaryTreeNode<char>('B', tree.Root);
            NJBinaryTreeNode<char> nodeC = new NJBinaryTreeNode<char>('C', tree.Root);
            NJBinaryTreeNode<char> nodeD = new NJBinaryTreeNode<char>('D', nodeB);
            NJBinaryTreeNode<char> nodeE = new NJBinaryTreeNode<char>('E', nodeB);
            NJBinaryTreeNode<char> nodeF = new NJBinaryTreeNode<char>('F', nodeE);
            NJBinaryTreeNode<char> nodeG = new NJBinaryTreeNode<char>('G', nodeE);
            NJBinaryTreeNode<char> nodeH = new NJBinaryTreeNode<char>('H', nodeC);
            NJBinaryTreeNode<char> nodeI = new NJBinaryTreeNode<char>('I', nodeH);

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

        void PreOrderTraversal(NJBinaryTreeNode<char> node) {
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
        
        void InOrderTraversal(NJBinaryTreeNode<char> node) {
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

        void PostOrderTraversal(NJBinaryTreeNode<char> node) {
            if (node == null)
                return;

            if (node.LeftChild != null)
            {
                PostOrderTraversal(node.LeftChild);
            }
            if (node.RightChild != null)
            {
                PostOrderTraversal(node.RightChild);
            }
                
            Debug.Log($"{node.Value} ");
        }

        void BreadthFirstTraversal(NJBinaryTreeNode<char> node) {
            if (node == null)
                return;

            LinkedList<NJBinaryTreeNode<char>> searchList = new LinkedList<NJBinaryTreeNode<char>>();
        }
    }
}