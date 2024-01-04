using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO.Collections
{
    public class MinimaxTreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public MinimaxTreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public IList<MinimaxTreeNode<T>> Children { get { return _children.AsReadOnly(); } }
        public int MinimaxScore { get { return _minimaxScore; } set { _minimaxScore = value; } }
        public int Count { get { return _children.Count; } }


        T _value;
        MinimaxTreeNode<T> _parent;
        List<MinimaxTreeNode<T>> _children;
        int _minimaxScore;


        // ----------------------------- CONSTRUCTORS ------------------------------
        public MinimaxTreeNode(T value, MinimaxTreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _children = new List<MinimaxTreeNode<T>>();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS ------------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}