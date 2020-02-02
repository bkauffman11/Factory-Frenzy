using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class NodeManager : MonoBehaviour 
{

    public Node starterNode;
    private int numNodes = 1;
    private Edge pendingConnection = null;
    private Tree tree = new Tree();
    private DataManager myDataManager = new DataManager();


	// Use this for initialization
	void Start () 
    {
        starterNode = new Node(new Vector2(50, 50), 40, 40, numNodes);
        tree.Nodes.Add(starterNode);
	}

    public void PaintNodes()
    {
        starterNode.Paint();

        foreach(Node node in tree.Nodes)
        {
            node.Paint();
        }
    }

    void OnGUI()
    {
        HandleEvents(Event.current);
        PaintNodes();
        PaintEdges();
    }


    void HandleEvents(Event e)
    {
        //TODO: make this a switch statement. 
        if (e.type == EventType.MouseDrag)
        {
            tree.HandleEvents(e);
        }
        if( e.type == EventType.MouseDown)
        {
            if(e.button == 1)
            {
                if(pendingConnection == null)
                {
                    Node clickedNode = tree.GetClickedNode(e.mousePosition);
                    if (clickedNode != null)
                    {
                        pendingConnection = new Edge(clickedNode);
                    }
                }
                else
                {
                    Node clickedNode = tree.GetClickedNode(e.mousePosition);
                    if(clickedNode != null)
                    {
                        pendingConnection.ToID = clickedNode.featureID;

                        if(pendingConnection.ToID != pendingConnection.FromID)
                        {
                            //TODO: add logic to make sure you don't add a connection that already exists. 
                            pendingConnection.InitByIds(tree);
                            tree.Edges.Add(pendingConnection);
                            DeletePendingConnection();
                        }
                       
                    }
                }
                
            }
        }
        if (e.type == EventType.KeyDown)
        {
            if(e.keyCode == KeyCode.Space)
            {
                OnAddNewNode(e.mousePosition);
            }
            else if(e.keyCode == KeyCode.Escape)
            {
                DeletePendingConnection();
            }
        }
            
    }

    private void PaintEdges()
    {
        if(pendingConnection != null)
        {
            pendingConnection.Paint(Event.current.mousePosition);
        }
        foreach (Edge edge in tree.Edges)
        {
            edge.Paint();
        }
    }

    void OnAddNewNode(Vector2 v2position)
    {
        numNodes++;
        Node node = new Node(new Vector2(v2position.x, 343-v2position.y), 40, 40, numNodes); // subtracting y from the height of the canvas, because position and mouse position are flipped. Thanks, U
        tree.Nodes.Add(node);
    }

    void OnCreateNewEdge(Node node)
    {
        pendingConnection = new Edge(node);
    }

    void DeletePendingConnection()
    {
        if(pendingConnection != null)
        {
            pendingConnection = null;
        }
    }

}
