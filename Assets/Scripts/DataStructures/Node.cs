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
    public Texture2D image = null;
    public int featureID;
    public Node LNode = null;
    public Node RNode = null;
    public bool IsLeafNode { get { return (LNode == null && RNode == null && ParentNode != null); } }
    public int[,] Data;


    public Node (Vector2 position, float width, float height, int ID)
    {
        box = new Rect(position, new Vector2(width, height));
        featureID = ID;
    }


    //If the node contains the mouse position, then drag it and return true. otherwise return false (meaning the node didn't drag).
    public bool HandleDragEvent(Event e)
    {
        if(e.type == EventType.MouseDrag)
        {
            if(box.Contains(e.mousePosition) && !IsLeafNode)
            {
                box.position += e.delta; // TODO: have it set to the mouse position, not the mouse drag. that way it will follow better. 
                if (LNode != null)
                {
                    LNode.box.position += e.delta;
                }
                if( RNode != null)
                {
                    RNode.box.position += e.delta;
                }
                return true;
            }
        }
        return false;
    }

    public void Paint()
    {
        if (IsLeafNode || image == null)
        {
            GUI.Box(box, "B");
        }
        else
        {
            GUI.DrawTexture(box, image);
        }
    }

    public void DrawImage()
    {
        GUI.DrawTexture(box, image);
    }

    public void SetParent(Node tNode)
    {
        ParentNode = tNode;
    }

}
