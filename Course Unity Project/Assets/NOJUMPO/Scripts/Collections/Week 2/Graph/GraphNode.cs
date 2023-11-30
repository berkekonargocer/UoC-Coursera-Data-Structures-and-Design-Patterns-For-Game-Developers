using System;
using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class GraphNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public IList<GraphNode<T>> Neighbors { get { return _neighbors.AsReadOnly(); } }

        T _value;
        List<GraphNode<T>> _neighbors;

        // ----------------------------- CONSTRUCTORS ------------------------------
        public GraphNode(T value) {
            _value = value;
            _neighbors = new List<GraphNode<T>>();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddNeighbor(GraphNode<T> neighbor) {
            if (_neighbors.Contains(neighbor))
            {
                return false;
            }

            _neighbors.Add(neighbor);
            return true;
        }

        public bool RemoveNeighbor(GraphNode<T> neighbor) {
            return _neighbors.Remove(neighbor);
        }

        public bool RemoveAllNeighbors() {
            for (int i = _neighbors.Count; i >= 0; i--)
            {
                _neighbors.RemoveAt(i);
            }

            return true;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}