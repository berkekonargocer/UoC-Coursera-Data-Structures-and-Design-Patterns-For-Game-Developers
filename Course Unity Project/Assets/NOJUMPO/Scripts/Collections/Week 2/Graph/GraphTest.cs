using NOJUMPO.Collections;
using UnityEngine;

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
            _intNJGraph.AddNode(2);
            _intNJGraph.AddNode(11);
            _intNJGraph.AddNode(17);

            _intNJGraph.AddEdge(9, 11, 32);
            _intNJGraph.AddEdge(9, 5, 37);
            _intNJGraph.AddEdge(11, 6, 78);
            _intNJGraph.AddEdge(6, 3, 12);
            _intNJGraph.AddEdge(11, 3, 26);
            _intNJGraph.AddEdge(11, 5, 59);
            _intNJGraph.AddEdge(11, 4, 91);
            _intNJGraph.AddEdge(5, 4, 69);
            _intNJGraph.AddEdge(5, 17, 7);
            _intNJGraph.AddEdge(4, 17, 82);
            _intNJGraph.AddEdge(4, 2, 16);
        }

        void Start() {
            Debug.Log($"{_intNJGraph}");
            Debug.Log(_intNJGraph.Search(9, 2, NJGraphSearchType.DEPTH_FIRST));
            // Debug.Log(_intNJGraph.Search(9, 2, NJGraphSearchType.BREADTH_FIRST));
            _intNJGraph.RemoveNode(5);
            Debug.Log($"{_intNJGraph}");
            NJGraphNode<int> neighborToLook = _intNJGraph.FindNode(4);
            NJGraphNode<int> nodeToLookItsNeighbor = _intNJGraph.FindNode(11);
            int edgeWeight = nodeToLookItsNeighbor.GetEdgeWeight(neighborToLook);
            Debug.Log($"Edge Weight Between {nodeToLookItsNeighbor.Value.ToString()} and {neighborToLook.Value.ToString()} is: {edgeWeight.ToString()}  ");

            // _intNJGraph.Nodes[6].GetEdgeWeight(neighborToLook);
        }
    }
}