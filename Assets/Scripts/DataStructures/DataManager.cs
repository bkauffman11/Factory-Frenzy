using UnityEngine;
using System.Collections;
using System.IO;
using System;

/// <summary>
/// This game logic agnostic class contains helper functions for reading, writing, and analyzing data. This class keeps the NodeManager class as light as possible. 
/// </summary>
public class DataManager : MonoBehaviour {

    int[,] i_dataSet;
    string path_DATASET = @"C:\Users\berna_000\Desktop\DATASET_TEXT.txt"; //TOOD: get this working on a build too. 

	// Use this for initialization
	void Start () 
    {
        ImportDataSet();
	}
	
    //function to parse the data set into various arrays
    string ImportDataSet()
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
        return "current value: " + (i_dataSet[1, 1] * 3) + "! wow so cool!";
    }


    public int[,] GetLeftData(int[,] data, int iFeatureID, float fSetPoint)
    {
        return i_dataSet;
    }

    public int[,] GetRightData(int[,] data, int iFeatureID, float fSetPoint)
    {
        return i_dataSet;
    }

}
