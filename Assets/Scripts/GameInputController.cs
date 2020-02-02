using UnityEngine;
using System.Collections;


/// <summary>
/// This class is agnostic of the data / gameplay logic. It mrerely handles the user pressing buttons. A separate game controller handles that
/// </summary>
public class GameInputController : MonoBehaviour {

    public GameController myGameController;
    public Camera mainCamera;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void StoreButtonClicked()
    {
        Application.LoadLevel(2);
    }

    public void PlayAgainButtonClicked()
    {
        Application.LoadLevel(1);
    }
}
