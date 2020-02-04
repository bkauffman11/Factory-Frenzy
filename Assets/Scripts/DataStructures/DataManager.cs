using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

/// <summary>
/// This game logic agnostic class contains helper functions for reading, writing, and analyzing data. This class keeps the NodeManager class as light as possible. 
/// </summary>
public class DataManager : MonoBehaviour {

    int[,] i_dataSet; //i_dataset[ROW, COLUMN] for reference!
    string path_DATASET = @"C:\Users\berna_000\Desktop\DATASET_TEXT.txt"; //TOOD: get this working on a build too. 
    int NumCandidates = 0;
    int NumFeatures = 0;

	// Use this for initialization
	void Start () 
    {

	}
	
    //function to parse the data set into various arrays
    public int[,] ImportDataSet()
    {

        StreamReader reader = new StreamReader(path_DATASET);
        string theWholeDataSet = reader.ReadToEnd();

        reader.Close();

        //Split the whole data set at line breaks
        string[] s_rows = theWholeDataSet.Split("\n"[0]);
        string[] s_columns = s_rows[0].Split(","[0]);

        //Store the number of rows and columns in the data set
        int numRows = s_rows.Length;
        int numColumns = s_columns.Length;

        //Initialize the data set to be a 2D array that an hold all our data
        string[,] s_dataSet = new string[numRows, numColumns];
        i_dataSet = new int[numRows, numColumns];

        //Nested for loop to populate our 2D array with data
        for (int i = 0; i < numRows; i++)
        {
            string[] column_Values = s_rows[i].Split(","[0]);

            for (int j = 0; j < column_Values.Length; j++)
            {
                s_dataSet[i, j] = column_Values[j];

                int myInt = -1;

                if (int.TryParse(column_Values[j], out myInt))
                {
                    i_dataSet[i, j] = myInt;
                }
            }

        }

        NumFeatures = i_dataSet.GetLength(0);
        NumCandidates = i_dataSet.GetLength(1);
        return i_dataSet;
    }


    public int[,] GetLeftData(int[,] data, int iFeatureID, float fSetPoint)
    {
        List<int> candidateIndices = new List<int>();
        for (int i = 0; i < data.GetLength(0); i++)
        {
            if(data[i, iFeatureID] < fSetPoint)
            {
                candidateIndices.Add(i);
            }
        }
        int[,] leftdata = new int[candidateIndices.Count, NumFeatures];
        int count = 0;

        //Fill up left data for every index in candidate indices
        foreach(int index in candidateIndices)
        {
            for(int i = 0; i < NumCandidates; i++)
            {
                leftdata[count, i] = data[index, i];
            }
            count ++;
        }
        return leftdata;
    }

    public int[,] GetRightData(int[,] data, int iFeatureID, float fSetPoint)
    {
        List<int> candidateIndices = new List<int>();
        for (int i = 0; i < data.GetLength(0); i++)
        {
            if (data[i, iFeatureID] >= fSetPoint)
            {
                candidateIndices.Add(i);
            }
        }
        int[,] rightdata = new int[candidateIndices.Count, NumFeatures];
        int count = 0;

        //Fill up right data for every index in candidate indices
        foreach (int index in candidateIndices)
        {
            for (int i = 0; i < NumCandidates; i++)
            {
                rightdata[count, i] = data[index, i];
            }
            count++;
        }
        return rightdata;
    }

}
