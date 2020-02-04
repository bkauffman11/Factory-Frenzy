using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tree : MonoBehaviour {

    public List<Node> Nodes = new List<Node>();
    public List<Edge> Edges = new List<Edge>();

    public Node GetNode(int nodeID)
    {
        foreach(Node node in Nodes)
        {
            if(node.featureID == nodeID)
            {
                return node;
            }
        }
        return null;
    }

    //Tells all the nodes to handle a drag event, returns the selected / dragged node or null if no node was selected. 
    public Node HandleDragEvent(Event e)
    {
        foreach(Node node in Nodes)
        {
            bool b = node.HandleDragEvent(e);
            if (b == true)
            {
                return node;
            }
        }
        return null;
    }

    public Node GetBucketAtPosition(Vector2 mousePosition)
    {
        foreach(Node node in Nodes)
        {
            if(node.IsLeafNode && node.featureID != -1 && node.box.Contains(mousePosition))
            {
                return node;
            }
        }
        return null;
    }

    //Removes the edge with the specified beginning and end node. 
    public void RemoveEdge(Node beginning, Node end)
    {
        foreach(Edge edge in Edges)
        {
            if(edge.FromID == beginning.featureID && edge.ToID == end.featureID)
            {
                Edges.Remove(edge);
                return;
            }
        }
    }

    public Node GetClickedNode(Vector2 mousePosition)
    {
        foreach(Node node in Nodes)
        {
            if (node.box.Contains(mousePosition))
                return node;
        }

        return null;
    }
}
