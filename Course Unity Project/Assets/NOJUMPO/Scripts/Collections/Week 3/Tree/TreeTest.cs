using NOJUMPO.Collections;
using UnityEngine;

namespace NOJUMPO
{
    public class TreeTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        NJTree<int> _intNJTree;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _intNJTree = BuildIntTree(999);
        }

        void Start() {
            Debug.Log($"Tree: {_intNJTree}");
        }
        NJTree<int> BuildIntTree(int rootNumber) {
            NJTree<int> intNJTree = new NJTree<int>(rootNumber);

            NJTreeNode<int> oddNumber1 = new NJTreeNode<int>(1, intNJTree.Root);
            NJTreeNode<int> oddNumber2 = new NJTreeNode<int>(3, oddNumber1);
            NJTreeNode<int> oddNumber3 = new NJTreeNode<int>(5, oddNumber1);
            NJTreeNode<int> oddNumber4 = new NJTreeNode<int>(7, oddNumber2);
            NJTreeNode<int> oddNumber5 = new NJTreeNode<int>(9, oddNumber2);
            NJTreeNode<int> oddNumber6 = new NJTreeNode<int>(11, oddNumber3);
            NJTreeNode<int> oddNumber7 = new NJTreeNode<int>(13, oddNumber3);

            intNJTree.AddNode(oddNumber1);
            intNJTree.AddNode(oddNumber2);
            intNJTree.AddNode(oddNumber3);
            intNJTree.AddNode(oddNumber4);
            intNJTree.AddNode(oddNumber5);
            intNJTree.AddNode(oddNumber6);
            intNJTree.AddNode(oddNumber7);

            NJTreeNode<int> evenNumber1 = new NJTreeNode<int>(0, intNJTree.Root);
            NJTreeNode<int> evenNumber2 = new NJTreeNode<int>(2, evenNumber1);
            NJTreeNode<int> evenNumber3 = new NJTreeNode<int>(4, evenNumber1);
            NJTreeNode<int> evenNumber4 = new NJTreeNode<int>(6, evenNumber2);
            NJTreeNode<int> evenNumber5 = new NJTreeNode<int>(8, evenNumber2);
            NJTreeNode<int> evenNumber6 = new NJTreeNode<int>(10, evenNumber3);
            NJTreeNode<int> evenNumber7 = new NJTreeNode<int>(12, evenNumber3);

            intNJTree.AddNode(evenNumber1);
            intNJTree.AddNode(evenNumber2);
            intNJTree.AddNode(evenNumber3);
            intNJTree.AddNode(evenNumber4);
            intNJTree.AddNode(evenNumber5);
            intNJTree.AddNode(evenNumber6);
            intNJTree.AddNode(evenNumber7);

            return intNJTree;
        }
    }
}