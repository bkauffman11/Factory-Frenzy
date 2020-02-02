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

    public void HandleEvents(Event e)
    {
        foreach(Node node in Nodes)
        {
            node.HandleEvent(e);
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
