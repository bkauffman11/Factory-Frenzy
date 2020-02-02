using UnityEngine;
using System.Collections;

public class TitleScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        PlayerPrefs.SetInt("LOCALSCORE", 0);
        PlayerPrefs.SetInt("MONEY", 0);
        PlayerPrefs.SetInt("NUM_LIVES", 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void StartButtonClicked()
    {
        Application.LoadLevel(1);
    }
}
