using System.Collections.Generic;
using System.Text;

namespace Nojumpo.Collections
{
    public class Graph<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public IList<GraphNode<T>> Nodes { get { return nodes.AsReadOnly(); } }
        public int Count { get { return nodes.Count; } }

        List<GraphNode<T>> nodes = new List<GraphNode<T>>();


        // ----------------------------- CONSTRUCTORS ------------------------------
        public Graph() {
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public GraphNode<T> FindNode(T value) {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Value.Equals(value))
                {
                    return nodes[i];
                }
            }

            return null;
        }

        public bool AddNode(T value) {
            if (FindNode(value) != null)
            {
                return false;
            }

            nodes.Add(new GraphNode<T>(value));
            return true;
        }

        public bool AddEdge(T value1, T value2) {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (node1.Neighbors.Contains(node2))
            {
                return false;
            }

            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
            return true;
        }

        public bool RemoveNode(T value) {
            GraphNode<T> nodeToRemove = FindNode(value);

            if (nodeToRemove == null)
            {
                return false;
            }

            nodes.Remove(nodeToRemove);

            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].RemoveNeighbor(nodeToRemove);
            }

            return true;
        }

        public bool RemoveEdge(T value1, T value2) {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (!node1.Neighbors.Contains(node2))
            {
                return false;
            }

            node1.RemoveNeighbor(node2);
            node2.RemoveNeighbor(node1);
            return true;
        }

        public void Clear() {
            foreach (GraphNode<T> graphNode in nodes)
            {
                graphNode.RemoveAllNeighbors();
            }

            for (int i = nodes.Count; i > 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }

        public override string ToString() {
            StringBuilder graphStringBuilder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                graphStringBuilder.Append(nodes[i]);

                if (i < Count - 1)
                {
                    graphStringBuilder.Append(",");
                }
            }

            return graphStringBuilder.ToString();
        }
    }
}