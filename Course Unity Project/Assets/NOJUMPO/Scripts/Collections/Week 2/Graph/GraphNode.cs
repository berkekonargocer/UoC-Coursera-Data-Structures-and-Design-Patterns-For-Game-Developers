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
            throw new NotImplementedException();
        }

        public bool RemoveNeighbor(GraphNode<T> neighbor) {
            throw new NotImplementedException();
        }

        public bool RemoveAllNeighbors() {
            throw new NotImplementedException();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}