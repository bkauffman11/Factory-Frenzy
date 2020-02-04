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
        string path = @"C:\Users\berna_000\Desktop\OUTPUT_TXT.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("======================================================");
        foreach(Node node in tree.Nodes)
        {
            string output = "\nNode: " + node.featureID;
            writer.Write(output);
        }

        writer.Close();
    }
}
