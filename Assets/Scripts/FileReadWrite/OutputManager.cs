using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class OutputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WriteOutput(Tree tree)
    {
        string path = "Assets\\Resources\\OUTPUT_TXT.csv";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("\n======================================================,");
        foreach(Node node in tree.Nodes)
        {
            if(node.IsLeafNode)
            {
                writer.WriteLine("X, " + node.ParentNode.featureID +",");
            }
            else
            {
                //write the node's feature ID, then parent node, then left node (if available), then right node.
                string nodeID = "" + node.featureID;
                string parentID = "-1";
                string LNodeID = "-1";
                string RNodeID = "-1";

                if(node.ParentNode != null)
                {
                    parentID = "" + node.ParentNode.featureID;
                }
                if(node.LNode != null)
                {
                    //TODO: does there have to be a different way to write buckets? I don't know man...
                    LNodeID = "" + node.LNode.featureID;

                }
                if(node.RNode != null)
                {
                    RNodeID = "" + node.RNode.featureID;
                }

                string output = node.featureID + ", " + parentID + ", " + LNodeID + ", " + RNodeID + ",";
                writer.WriteLine(output);
            }
        }
        writer.Close();
    }
}
