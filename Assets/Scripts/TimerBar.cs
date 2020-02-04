using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBar : MonoBehaviour {

    public GameObject timerBar;
    public GameController myGameController;
    public ScoreBar scoreBar;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private float difficulty;
    private bool isGamePaused;

	// Use this for initialization
	void Start () 
    {
        
        isGamePaused = false;
        currentPosition = timerBar.transform.position;
        difficulty = currentPosition.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isGamePaused)
        {
            currentPosition = timerBar.transform.position;
            float delta = PlayerPrefs.GetFloat("DIFFICULTY");
            difficulty = difficulty - .010f; // TODO: turn this into a sliding difficulty scale. It's fucking annoying to have it get faster everytime I play... probably means people will hate it too. 
            //TODO: have the game controller control the difficulty, not the TimerBar. Remember that these are entirely agnostic of game logic. They only handle their own functionality!
            
            if(difficulty > 0)
            {
                int xPosition = (int)difficulty;
                newPosition = new Vector3(xPosition, currentPosition.y, currentPosition.z);
                timerBar.transform.position = newPosition;
            }
            else
            {
                myGameController.GameOver();
            }

        }
	}

    public void SetIsPaused(bool tBool)
    {
        isGamePaused = tBool;
    }

    public float GetDifficulty()
    {
        return difficulty;
    }
    
    public void SetDifficulty(float tDifficulty)
    {
        difficulty = tDifficulty;
    }
}
