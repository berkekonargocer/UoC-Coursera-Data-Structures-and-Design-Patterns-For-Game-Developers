using System;
using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class GraphNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public IDictionary<GraphNode<T>, int> Neighbors { get { return _neighbors; } }

        T _value;
        Dictionary<GraphNode<T>, int> _neighbors;

        // ----------------------------- CONSTRUCTORS ------------------------------
        public GraphNode(T value) {
            _value = value;
            _neighbors = new Dictionary<GraphNode<T>, int>();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public int GetEdgeWeight(GraphNode<T> neighbor) {
            if (!_neighbors.ContainsKey(neighbor))
            {
                throw new InvalidOperationException("Trying to retrieve weight of an non-existent edge");
            }

            return _neighbors[neighbor];
        }
        
        public bool AddNeighbor(GraphNode<T> neighbor, int edgeWeight) {
            if (_neighbors.ContainsKey(neighbor))
            {
                return false;
            }

            _neighbors.Add(neighbor, edgeWeight);
            return true;
        }

        public bool RemoveNeighbor(GraphNode<T> neighbor) {
            return _neighbors.Remove(neighbor);
        }

        public bool RemoveAllNeighbors() {
            foreach (KeyValuePair<GraphNode<T>, int> keyValuePair in _neighbors)
            {
                _neighbors.Remove(keyValuePair.Key);
            }

            return true;
        }

        public override string ToString() {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append($"[Node Value: {_value} Neighbors: ");

            int iteration = -1;
            foreach (KeyValuePair<GraphNode<T>, int> keyValuePair in _neighbors)
            {
                iteration++;
                nodeString.Append($"(Value: {keyValuePair.Key.Value}, Edge Weight: {keyValuePair.Value})");

                if (iteration < _neighbors.Count - 1)
                {
                    nodeString.Append(", ");
                }
            }

            nodeString.Append("] \n");
            return nodeString.ToString();
        }
    }
}