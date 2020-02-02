using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
 * tree.Nodes the basic structures of a decision tree. A node contians a pointer to only one parent. A node can have pointers to a left node and a right node children
 * tree.Nodes have a feature ID number corresponding to their column in the data set
 * tree.Nodes have a set point, or dividing point that sends candidates left or right based on whether they are less than the set point
 */

public class Node
{
    public Node ParentNode = null;
    public Rect box;
    public int featureID;
    public int Text;
    public Node LNode = null;
    public Node RNode = null;
    public bool IsLeafNode { get { return (LNode == null && RNode == null && ParentNode != null); } }


    public Node (Vector2 position, float width, float height, int ID)
    {
        box = new Rect(position, new Vector2(width, height));
        Text = ID;
        featureID = ID;
    }


    public void HandleEvent(Event e)
    {
        if(e.type == EventType.MouseDrag)
        {
            if(box.Contains(e.mousePosition))
            {
                box.position += e.delta; // TODO: have it set to the mouse position, not the mouse drag. that way it will follow better. 
            }
        }
    }

    public void Paint()
    {
        GUI.Box(box, "#: " + Text);
    }

    public void SetParent(Node tNode)
    {
        ParentNode = tNode;
    }

}
