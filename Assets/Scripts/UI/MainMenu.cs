using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}

    public void GoToCredits()
    {
        Application.LoadLevel("Credits");
    }

    public void GoToTutorial()
    {
        Application.LoadLevel("Tutorial");
    }

    public void  GoToGameStart()
    {
        Application.LoadLevel("GameStart");
    }
}