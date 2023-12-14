using Nojumpo.Collections;
using UnityEngine;

namespace Nojumpo
{
    public class TreeTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Tree<int> _intTree;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _intTree = BuildIntTree(999);
        }

        void Start() {
            Debug.Log($"Tree: {_intTree}");
        }
        Tree<int> BuildIntTree(int rootNumber) {
            Tree<int> intTree = new Tree<int>(rootNumber);

            TreeNode<int> oddNumber1 = new TreeNode<int>(1, intTree.Root);
            TreeNode<int> oddNumber2 = new TreeNode<int>(3, oddNumber1);
            TreeNode<int> oddNumber3 = new TreeNode<int>(5, oddNumber1);
            TreeNode<int> oddNumber4 = new TreeNode<int>(7, oddNumber2);
            TreeNode<int> oddNumber5 = new TreeNode<int>(9, oddNumber2);
            TreeNode<int> oddNumber6 = new TreeNode<int>(11, oddNumber3);
            TreeNode<int> oddNumber7 = new TreeNode<int>(13, oddNumber3);

            intTree.AddNode(oddNumber1);
            intTree.AddNode(oddNumber2);
            intTree.AddNode(oddNumber3);
            intTree.AddNode(oddNumber4);
            intTree.AddNode(oddNumber5);
            intTree.AddNode(oddNumber6);
            intTree.AddNode(oddNumber7);

            TreeNode<int> evenNumber1 = new TreeNode<int>(0, intTree.Root);
            TreeNode<int> evenNumber2 = new TreeNode<int>(2, evenNumber1);
            TreeNode<int> evenNumber3 = new TreeNode<int>(4, evenNumber1);
            TreeNode<int> evenNumber4 = new TreeNode<int>(6, evenNumber2);
            TreeNode<int> evenNumber5 = new TreeNode<int>(8, evenNumber2);
            TreeNode<int> evenNumber6 = new TreeNode<int>(10, evenNumber3);
            TreeNode<int> evenNumber7 = new TreeNode<int>(12, evenNumber3);

            intTree.AddNode(evenNumber1);
            intTree.AddNode(evenNumber2);
            intTree.AddNode(evenNumber3);
            intTree.AddNode(evenNumber4);
            intTree.AddNode(evenNumber5);
            intTree.AddNode(evenNumber6);
            intTree.AddNode(evenNumber7);

            return intTree;
        }
    }
}