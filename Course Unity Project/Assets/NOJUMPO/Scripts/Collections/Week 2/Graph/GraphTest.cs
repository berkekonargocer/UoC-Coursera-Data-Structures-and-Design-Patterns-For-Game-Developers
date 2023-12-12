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
            _intGraph.AddNode(6);
            _intGraph.AddNode(4);
            _intGraph.AddEdge(9, 5, 37);
            _intGraph.AddEdge(9, 3, 78);
            _intGraph.AddEdge(9, 6, 51);
            _intGraph.AddEdge(9, 4, 32);
            _intGraph.AddEdge(5, 3, 12);
            _intGraph.AddEdge(5, 4, 26);
        }

        void Start() {
            Debug.Log($"{_intGraph}");
            _intGraph.RemoveNode(5);
            Debug.Log($"{_intGraph}");
            GraphNode<int> neighborToLook = _intGraph.FindNode(3);
            _intGraph.Nodes[0].GetEdgeWeight(neighborToLook);
        }
    }
}