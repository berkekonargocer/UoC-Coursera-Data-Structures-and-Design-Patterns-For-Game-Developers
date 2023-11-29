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


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}