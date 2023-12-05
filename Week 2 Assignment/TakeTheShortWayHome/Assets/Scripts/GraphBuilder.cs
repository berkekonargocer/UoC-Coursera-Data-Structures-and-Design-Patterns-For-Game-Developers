using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph = new Graph<Waypoint>();

    #region Constructor

    // Uncomment the code below after copying this class into the console
    // app for the automated grader. DON'T uncomment it now; it won't
    // compile in a Unity project

    /// <summary>
    /// Constructor
    /// 
    /// Note: The GraphBuilder class in the Unity solution doesn't 
    /// use a constructor; this constructor is to support automated grading
    /// </summary>
    /// <param name="gameObject">the game object the script is attached to</param>
    //public GraphBuilder(GameObject gameObject) :
    //    base(gameObject)
    //{
    //}

    #endregion


    public void Awake()
    {
        // add nodes (all waypoints, including start and end) to graph
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Waypoint");
        Waypoint start = GameObject.FindWithTag("Start").GetComponent<Waypoint>();
        Waypoint finish = GameObject.FindWithTag("Finish").GetComponent<Waypoint>();

        graph.AddNode(start);
        graph.AddNode(finish);
        foreach (GameObject gObject in gameObjects)
        {
             graph.AddNode(gObject.GetComponent<Waypoint>());
        }

        // add neighbors for each node in graph
        foreach (GraphNode<Waypoint> node1 in graph.Nodes)
        {
            foreach (GraphNode<Waypoint> node2 in graph.Nodes)
            {
                if (node1 != node2)
                {
                    Vector2 distance = node1.Value.Position - node2.Value.Position;

                    if (Mathf.Abs(distance.x) < 3.5f && Mathf.Abs(distance.y) < 3.0f)
                    {
                        node1.AddNeighbor(node2, distance.magnitude);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets and sets the graph
    /// 
    /// CAUTION: Set should only be used by the autograder
    /// </summary>
    /// <value>graph</value>
    public static Graph<Waypoint> Graph
    {
        get { return graph; }
        set { graph = value; }
    }
}
