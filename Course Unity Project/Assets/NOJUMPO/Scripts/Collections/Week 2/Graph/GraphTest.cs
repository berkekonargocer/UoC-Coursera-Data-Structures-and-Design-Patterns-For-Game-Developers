using UnityEngine;
using Nojumpo.Collections;

namespace Nojumpo
{
    public class GraphTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        Graph<int> intGraph = new Graph<int>();

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            intGraph.AddNode(9);
            intGraph.AddNode(5);
            intGraph.AddNode(3);
            intGraph.AddEdge(9, 5);
            intGraph.AddEdge(9, 3);
            intGraph.AddEdge(5, 3);
        }

        void Start() {
            Debug.Log($"{intGraph}");
        }
    }
}