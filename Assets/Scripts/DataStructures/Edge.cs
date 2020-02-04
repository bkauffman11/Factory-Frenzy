using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Edge {

    public int FromID;
    public int ToID;
    public Node FromItem;
    public Node ToItem;

    public Edge(Node from)
    {
        FromID = from.featureID;
        FromItem = from;
        ToItem = null;
    }

    public void InitByIds(Tree tree)
    {
        FromItem = tree.GetNode(FromID);
        ToItem = tree.GetNode(ToID);
    }


    public void Paint()
    {
        if (FromItem == null || ToItem == null)
            return;

        Handles.color = Color.white;

        Vector2 pStart = new Vector2(FromItem.box.width / 2 + FromItem.box.x, FromItem.box.height + FromItem.box.y);

        Vector2 pEnd = new Vector2(ToItem.box.width / 2 + ToItem.box.x, ToItem.box.y - 5);

        Vector3[] points = new Vector3[2];

        points[0] = pStart;
        points[1] = pEnd;

        Handles.DrawAAPolyLine(4, points);

        //TODO: draw the rectangle above the node. 

        //Rect rect = new Rect(pEnd.x - 5, pEnd.y, 10, 5);

        //Handles.DrawSolidRectangleWithOutline(rect, Color.white, Color.grey);
    }

    public void Paint(Vector2 mousePosition)
    {
        if (FromItem == null)
            return;

        Handles.color = Color.white;
        Vector2 pStart = new Vector2(FromItem.box.width / 2 + FromItem.box.x, FromItem.box.y + FromItem.box.height);
        Handles.DrawLine(pStart, mousePosition); 
    }
}
