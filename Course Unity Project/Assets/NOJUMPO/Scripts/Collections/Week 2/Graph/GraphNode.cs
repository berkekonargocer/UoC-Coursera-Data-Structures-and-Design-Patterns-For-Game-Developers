using System.Collections.Generic;
using System.Text;

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

        public override string ToString() {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append($"[Node Value:{_value} Neighbors: ");

            for (int i = 0; i < _neighbors.Count; i++)
            {
                nodeString.Append($"{_neighbors[i]._value}");

                if (i < _neighbors.Count - 1)
                {
                    nodeString.Append(", ");
                }
            }

            nodeString.Append("]");
            return nodeString.ToString();
        }
    }
}