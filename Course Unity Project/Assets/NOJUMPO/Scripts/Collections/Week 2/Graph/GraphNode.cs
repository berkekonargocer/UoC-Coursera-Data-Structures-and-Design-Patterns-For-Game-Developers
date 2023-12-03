using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class GraphNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public int Weight { get { return _weight; } }
        public IDictionary<GraphNode<T>, int> Neighbors { get { return _neighbors; } }

        T _value;
        int _weight;
        Dictionary<GraphNode<T>, int> _neighbors;

        // ----------------------------- CONSTRUCTORS ------------------------------
        public GraphNode(T value, int weight) {
            _value = value;
            _weight = weight;
            _neighbors = new Dictionary<GraphNode<T>, int>();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public bool AddNeighbor(GraphNode<T> neighbor) {
            if (_neighbors.ContainsKey(neighbor))
            {
                return false;
            }

            _neighbors.Add(neighbor, neighbor.Weight);
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
            nodeString.Append($"[Node Value: {_value}, Node Weight: {_weight} Neighbors: ");

            int iteration = -1;
            foreach (KeyValuePair<GraphNode<T>, int> keyValuePair in _neighbors)
            {
                iteration++;
                nodeString.Append($"(Value: {keyValuePair.Key.Value}, Weight: {keyValuePair.Key.Weight})");

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