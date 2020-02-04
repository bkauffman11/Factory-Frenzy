using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class filePathPrompter : MonoBehaviour 
{
    public GameObject inputField;
    public GameObject text;
    public TextAsset file;
    string filePath;

    public void onFilePathEntered()
    {

        filePath = inputField.GetComponent<Text>().text;

        //See if we can read the dataset correctly. 
        try
        {
            StreamReader reader = new StreamReader(filePath);

            PlayerPrefs.SetString("BasePath", filePath);
            Application.LoadLevel(1);
        }
        catch
        {
            PlayerPrefs.SetString("BasePath", "ERROR");
            //PlayerPrefs.SetString("BasePath", Application.persistentDataPath + "\\Assets\\StreamingAssets\\DATASET_TEXT.txt");
            Application.LoadLevel(1);
        }
    }
	
}
