using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour 
{

    public Node rootNode;
    public Texture2D[] images;
    public Texture2D bucketImage;
    private int numNodes = 1;
    private Edge pendingConnection = null;
    private Tree tree = new Tree();
    private DataManager myDataManager = new DataManager();
    private Node draggedNode = null;

	void Start () 
    {
        myDataManager.ImportDataSet();

        //TODO: get all this custom stuff into its own function. 
        rootNode = new Node(new Vector2(250, 50), 40, 40, numNodes);
        rootNode.image = images[Random.Range(0, images.Length)];
        tree.Nodes.Add(rootNode);
        AddBuckets(rootNode);
        SetUpNodes();
	}

    public void PaintNodes()
    {
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
        rootNode.DrawImage();
    }

    public void SetUpNodes()
    {
        for(int i = 1; i < 5; i++)
        {
            Node node = OnAddNewNode(new Vector2(50, 50 + 50*i));
            node.image = images[Random.Range(0, images.Length)];
        }
    }

    void HandleEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDrag:
                //Get the selected / dragged node. 
                draggedNode = tree.HandleDragEvent(e);
                break;
            case EventType.MouseDown:
                if(e.button == 1)
                {
                    if (pendingConnection == null)
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
                        if (clickedNode != null)
                        {
                            pendingConnection.ToID = clickedNode.featureID;
                            if (pendingConnection.ToID != pendingConnection.FromID)
                            {
                                //TODO: make sure that there aren't any existing edges with the same beginning and end (or end and beginning) as our pending connection.
                                //TODO: make this into a function.
                                pendingConnection.InitByIds(tree);
                                pendingConnection.ToItem.SetParent(pendingConnection.FromItem);
                                tree.Edges.Add(pendingConnection);
                                DeletePendingConnection();
                            }
                        }
                    }
                }
                break;
            case EventType.KeyDown:
                if (e.keyCode == KeyCode.Space)
                {
                    OnAddNewNode(e.mousePosition);
                }
                else if (e.keyCode == KeyCode.Escape)
                {
                    DeletePendingConnection();
                }
                break;
            case EventType.MouseUp:
                if(e.button == 0)
                {
                    if(draggedNode != null)
                    {
                        //TODO: make this into a new fxn

                        //Find out what bucket, if any is present in the spot. 
                        Node bucketNode = tree.GetBucketAtPosition(e.mousePosition);

                        if (bucketNode != null)
                        {
                            Debug.Log("Bernard, you did it. Believe in yourself from now on.");

                            //Add the currently dragged node to the parent's left or right pointer.
                            if(bucketNode.Equals(bucketNode.ParentNode.LNode))
                            {
                                bucketNode.ParentNode.LNode = draggedNode;
                            }
                            else if(bucketNode.Equals(bucketNode.ParentNode.RNode))
                            {
                                bucketNode.ParentNode.LNode = draggedNode;
                            }

                            //Delete the bucket node.
                            tree.Nodes.Remove(bucketNode);

                            //remove the edge from the bucket's parent to the bucket. 
                            tree.RemoveEdge(bucketNode.ParentNode, bucketNode);

                            //add a new edge from the dragged node's parent to the dragged node.
                            Edge newEdge = new Edge(bucketNode.ParentNode);
                            newEdge.ToID = draggedNode.featureID;
                            newEdge.InitByIds(tree);
                            tree.Edges.Add(newEdge);


                            //TODO: MAKE THIS AN AUTOMAGIC FUNCTION FOR DELETING NODES. 

                            //call add buckets to the new node. 
                            AddBuckets(draggedNode);
                        }

                        draggedNode = null; //when you release, you're not dragging!
                    }
                }

                break;
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

    public Node OnAddNewNode(Vector2 v2position)
    {
        numNodes++;
        Node node = new Node(new Vector2(v2position.x, v2position.y), 40, 40, numNodes); // TODO: Not make this hard-coded.
        tree.Nodes.Add(node);
        return node;
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

    public void AddBuckets(Node node)
    {
        Debug.Log("Y: " + node.box.y);
        //Add buckets to node. 
        Node LeftBucket = OnAddNewNode(new Vector2(node.box.x -40, node.box.y + 50)); //TODO: make this NOT hardcoded. 
        node.LNode = LeftBucket;
        LeftBucket.ParentNode = node;

        Node RightBucket = OnAddNewNode(new Vector2(node.box.x + 40, node.box.y +50)); //TODO: make this NOT hardcoded. 
        node.RNode = RightBucket;
        RightBucket.ParentNode = node;

        //make new connections. 
        Edge LeftEdge = new Edge(node);
        LeftEdge.ToID = LeftBucket.featureID;
        LeftEdge.InitByIds(tree);
        tree.Edges.Add(LeftEdge);

        Edge RightEdge = new Edge(node);
        RightEdge.ToID = RightBucket.featureID;
        RightEdge.InitByIds(tree);
        tree.Edges.Add(RightEdge);

        Debug.Log("RIGHT Y: " + LeftBucket.box.y);
    }

}
