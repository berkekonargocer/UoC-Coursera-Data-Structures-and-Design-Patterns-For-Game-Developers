using System.Collections.Generic;

namespace Nojumpo.Collections
{
    public class Graph<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public IList<GraphNode<T>> Nodes { get { return nodes.AsReadOnly(); } }
        public int Count { get { return nodes.Count;} }

        List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        
        
        // ----------------------------- CONSTRUCTORS ------------------------------
        public Graph() {
                
        }
    }
}