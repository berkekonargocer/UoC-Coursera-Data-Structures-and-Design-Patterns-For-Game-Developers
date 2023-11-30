using System.Collections.Generic;

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
        public GraphNode<T> Find(T value) {
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
            if (Find(value) != null)
            {
                return false;
            }
            
            nodes.Add(new GraphNode<T>(value));
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
    }
}