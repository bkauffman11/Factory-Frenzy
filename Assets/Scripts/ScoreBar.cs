using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour {

    public GameObject scoreBar;
    public GameController gameController;
    public Text scoreText;
    private int score;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private bool isGamePaused = false;

	// Use this for initialization
	void Start () 
    {
        score = 0;
        currentPosition = scoreBar.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void UpdateScore(int delta)
    {
        if(!isGamePaused)
        {
            score += delta;
            currentPosition = scoreBar.transform.position;
            newPosition = new Vector3(currentPosition.x, currentPosition.y + delta, currentPosition.z);
            
            if (newPosition.y > 125)
            {
                MinimumScoreAchieved();
            }
            else if (newPosition.y > 250)
            {
                MaxScoreAchieved();
            }

            scoreBar.transform.position = newPosition;
            PlayerPrefs.SetInt("LOCALSCORE", score);
            scoreText.text = "" + PlayerPrefs.GetInt("LOCALSCORE", score);
        }
    }

    public void SetIsPaused(bool tBool)
    {
        isGamePaused = tBool;
    }

    void MaxScoreAchieved()
    {
        gameController.MaxScoreAchieved();
    }

    void MinimumScoreAchieved()
    {
        gameController.MinScoreAchieved();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int tInt)
    {
        score = tInt;
    }
}
