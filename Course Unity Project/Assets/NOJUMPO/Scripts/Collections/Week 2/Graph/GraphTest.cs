using UnityEngine;
using Nojumpo.Collections;

namespace Nojumpo
{
    public class GraphTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        readonly Graph<int> _intGraph = new Graph<int>();

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _intGraph.AddNode(9);
            _intGraph.AddNode(5);
            _intGraph.AddNode(3);
            _intGraph.AddEdge(9, 5);
            _intGraph.AddEdge(9, 3);
            _intGraph.AddEdge(5, 3);
        }

        void Start() {
            Debug.Log($"{_intGraph}");
            _intGraph.RemoveNode(5);
            Debug.Log($"{_intGraph}");
        }
    }
}