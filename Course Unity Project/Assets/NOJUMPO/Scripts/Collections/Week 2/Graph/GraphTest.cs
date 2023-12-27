using UnityEngine;
using NOJUMPO.Collections;

namespace NOJUMPO
{
    public class GraphTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        readonly NJGraph<int> _intNJGraph = new NJGraph<int>();
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _intNJGraph.AddNode(9);
            _intNJGraph.AddNode(5);
            _intNJGraph.AddNode(3);
            _intNJGraph.AddNode(6);
            _intNJGraph.AddNode(4);
            _intNJGraph.AddEdge(9, 5, 37);
            _intNJGraph.AddEdge(3, 6, 78);
            // _intNJGraph.AddEdge(9, 6, 51);
            _intNJGraph.AddEdge(9, 4, 32);
            _intNJGraph.AddEdge(5, 3, 12);
            _intNJGraph.AddEdge(5, 4, 26);
        }

        void Start() {
            Debug.Log($"{_intNJGraph}");
            Debug.Log(_intNJGraph.Search(9, 6, NJGraphSearchType.DEPTH_FIRST));
            _intNJGraph.RemoveNode(5);
            Debug.Log($"{_intNJGraph}");
            NJGraphNode<int> neighborToLook = _intNJGraph.FindNode(4);
            int edgeWeight = _intNJGraph.Nodes[0].GetEdgeWeight(neighborToLook);
            Debug.Log($"Edge Weight Between {_intNJGraph.Nodes[0].Value.ToString()} and {neighborToLook.Value.ToString()} is: {edgeWeight.ToString()}  ");
            // _intNJGraph.FindNode(9).GetEdgeWeight(_intNJGraph.FindNode(4));
        }
    }
}