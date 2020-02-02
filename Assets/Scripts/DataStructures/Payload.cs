using UnityEngine;
using System.Collections;


/// <summary>
/// A Payload is the base data structure in Factory Frenzy. A payload class is a wrapper for a two dimensional array of integers (or floats) that 
/// </summary>
public class Payload
{
    public int[,] data;

    //-------------------------------------------------------------------------------------------------------------------------
    //FUNCTIONS GO HERE!
    //-------------------------------------------------------------------------------------------------------------------------

    //Constructor that sets a payload based off of this information
    public Payload(int[,] tData)
    {
        data = tData;
    }


    /// <summary>
    /// returns an integer corresponding to the value 
    /// </summary>
    /// <param name="row"> The column/feature that the value is on in the data set</param>
    /// <param name="column"> The row / candidate that the value is on in the data set</param>
    /// <returns></returns>
    public int get(int row, int column)
    {
        return data[row, column];
    }

    /// <summary>
    /// This function returns the number of candidates within the Payload.
    /// </summary>
    /// <returns> data.getLength(0+ -> the length of the first dimension of the array, or the number of columns in the data set. </returns>
    public int getNumCandidates()
    {
        return data.GetLength(0);
    }

    public int getNumFeatures()
    {
        return data.GetLength(1);
    }

    /// <summary>
    /// Returns the data contained within a payload
    /// </summary>
    /// <returns> </returns>
    public int[,] getData()
    {
        return data;
    }

    public float getScore()
    {

        float numSuccessful = 0.0f;
        float numUnsuccessful = 0.0f;
        for(int i = 0; i < data.GetLength(1); i++)
        {

            if(data[0, i] == 0)
            {
                numSuccessful++;
            }
            else
            {
                numUnsuccessful++;
            }
        }

        float x = numUnsuccessful + numSuccessful;

        float y = numSuccessful - numUnsuccessful;

        float score = Mathf.Abs((x - y) / x);

        return score;
    }
}
