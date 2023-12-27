using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NOJUMPO.Collections
{
    public class NJGraph<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public IList<NJGraphNode<T>> Nodes { get { return nodes.AsReadOnly(); } }
        public int Count { get { return nodes.Count; } }

        List<NJGraphNode<T>> nodes = new List<NJGraphNode<T>>();


        // ----------------------------- CONSTRUCTORS ------------------------------
        public NJGraph() {
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public NJGraphNode<T> FindNode(T nodeValue) {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Value.Equals(nodeValue))
                {
                    return nodes[i];
                }
            }

            return null;
        }

        public bool AddNode(T nodeValue) {
            if (FindNode(nodeValue) != null)
            {
                return false;
            }

            nodes.Add(new NJGraphNode<T>(nodeValue));
            return true;
        }

        public bool AddEdge(T node1Value, T node2Value, int edgeWeight) {
            NJGraphNode<T> node1 = FindNode(node1Value);
            NJGraphNode<T> node2 = FindNode(node2Value);

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (node1.Neighbors.ContainsKey(node2))
            {
                return false;
            }

            node1.AddNeighbor(node2, edgeWeight);
            return true;
        }

        public bool RemoveNode(T nodeValue) {
            NJGraphNode<T> nodeToRemove = FindNode(nodeValue);

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
            NJGraphNode<T> node1 = FindNode(node1Value);
            NJGraphNode<T> node2 = FindNode(node2Value);

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
            foreach (NJGraphNode<T> graphNode in nodes)
            {
                graphNode.RemoveAllNeighbors();
            }

            for (int i = nodes.Count; i > 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }

        public string Search(T startNode, T finishNode, NJGraphSearchType njGraphSearchType) {
            LinkedList<NJGraphNode<T>> searchList = new LinkedList<NJGraphNode<T>>();

            if (startNode.Equals(finishNode))
            {
                return startNode.ToString();
            }

            if (FindNode(startNode) == null)
            {
                return "Start Node is Null";
            }

            if (FindNode(finishNode) == null)
            {
                return "Finish Node is Null";
            }

            NJGraphNode<T> startingNode = FindNode(startNode);
            Dictionary<NJGraphNode<T>, NJGraphNode<T>> pathNodes = new Dictionary<NJGraphNode<T>, NJGraphNode<T>>();

            pathNodes.Add(startingNode, null);
            searchList.AddFirst(startingNode);

            while (searchList.Count > 0)
            {
                NJGraphNode<T> currentNode = searchList.First.Value;
                searchList.RemoveFirst();

                foreach (KeyValuePair<NJGraphNode<T>, int> neighbor in currentNode.Neighbors)
                {
                    if (neighbor.Key.Value.Equals(finishNode))
                    {
                        pathNodes.Add(neighbor.Key, currentNode);
                        return ConvertPathToString(neighbor.Key, pathNodes);
                    }

                    if (pathNodes.ContainsKey(neighbor.Key))
                    {
                        continue;
                    }

                    pathNodes.Add(neighbor.Key, currentNode);

                    if (njGraphSearchType == NJGraphSearchType.DEPTH_FIRST)
                    {
                        searchList.AddFirst(neighbor.Key);
                    }
                    else
                    {
                        searchList.AddLast(neighbor.Key);
                    }

                    Debug.Log($"Just Added {neighbor.Key.Value}");
                }
            }

            return "The Path Is Not Existent";
        }

        string ConvertPathToString(NJGraphNode<T> endNode, Dictionary<NJGraphNode<T>, NJGraphNode<T>> pathNodes) {
            // build linked list for path in correct order
            LinkedList<NJGraphNode<T>> path = new LinkedList<NJGraphNode<T>>();
            path.AddFirst(endNode);
            NJGraphNode<T> previous = pathNodes[endNode];

            while (previous != null)
            {
                path.AddFirst(previous);
                previous = pathNodes[previous];
            }

            // build and return string
            StringBuilder pathString = new StringBuilder();
            LinkedListNode<NJGraphNode<T>> currentNode = path.First;
            int nodeCount = 0;

            while (currentNode != null)
            {
                nodeCount++;
                pathString.Append(currentNode.Value.Value);

                if (nodeCount < path.Count)
                {
                    pathString.Append(" ");
                }

                currentNode = currentNode.Next;
            }

            return pathString.ToString();
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