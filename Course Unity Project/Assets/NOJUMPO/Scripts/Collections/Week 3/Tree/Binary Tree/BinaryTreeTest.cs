using System.Collections.Generic;
using NOJUMPO.Collections;
using UnityEngine;

namespace NOJUMPO
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

            tree.AddNode(nodeB, NJTreeNodeChildSide.LEFT);
            tree.AddNode(nodeC, NJTreeNodeChildSide.RIGHT);
            tree.AddNode(nodeD, NJTreeNodeChildSide.LEFT);
            tree.AddNode(nodeE, NJTreeNodeChildSide.RIGHT);
            tree.AddNode(nodeF, NJTreeNodeChildSide.LEFT);
            tree.AddNode(nodeG, NJTreeNodeChildSide.RIGHT);
            tree.AddNode(nodeH, NJTreeNodeChildSide.RIGHT);
            tree.AddNode(nodeI, NJTreeNodeChildSide.LEFT);

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