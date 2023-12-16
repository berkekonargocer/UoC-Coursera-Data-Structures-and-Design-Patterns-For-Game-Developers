using System;
using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class BinaryTree<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public BinaryTreeNode<T> Root { get { return _root; } }
        public int Count { get { return _nodes.Count; } }

        BinaryTreeNode<T> _root = null;
        List<BinaryTreeNode<T>> _nodes = new List<BinaryTreeNode<T>>();

        // ----------------------------- CONSTRUCTORS ------------------------------
        public BinaryTree(T value) {
            _root = new BinaryTreeNode<T>(value, null);
            _nodes.Add(_root);
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddNode(BinaryTreeNode<T> nodeToAdd, ChildSide childSide) {
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
        

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}