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
        public GraphNode<T> FindNode(T nodeValue) {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Value.Equals(nodeValue))
                {
                    return nodes[i];
                }
            }

            return null;
        }

        public bool AddNode(T nodeValue, int weight) {
            if (FindNode(nodeValue) != null)
            {
                return false;
            }

            nodes.Add(new GraphNode<T>(nodeValue, weight));
            return true;
        }
        
        public bool AddEdge(T node1Value, T node2Value) {
            GraphNode<T> node1 = FindNode(node1Value);
            GraphNode<T> node2 = FindNode(node2Value);

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (node1.Neighbors.ContainsKey(node2))
            {
                return false;
            }

            node1.AddNeighbor(node2);
            return true;
        }

        public bool RemoveNode(T nodeValue) {
            GraphNode<T> nodeToRemove = FindNode(nodeValue);

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

        public bool RemoveEdge(T node1Value, T node2Value) {
            GraphNode<T> node1 = FindNode(node1Value);
            GraphNode<T> node2 = FindNode(node2Value);

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (!node1.Neighbors.ContainsKey(node2))
            {
                return false;
            }

            node1.RemoveNeighbor(node2);
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
                    graphStringBuilder.Append(", ");
                }
            }

            return graphStringBuilder.ToString();
        }
    }
}