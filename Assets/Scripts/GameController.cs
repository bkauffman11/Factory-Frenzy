using UnityEngine;
using UnityEngine.UI; //TODO: Make a UI Controller to handle all the text updating and game object showing / hiding. Controller is JUST GAME LOGIC.
using System.Collections;

public class GameController : MonoBehaviour 
{

    public ScoreBar scoreBar;
    public TimerBar timerBar;
    public GameInputController inputController;
    public GameObject gameOverTextParent;
    public GameObject maxScoreTextParent;
    public GameObject myContinueButton;
    public Text lifetimeScore;
    public Text numLives;
    private bool isGameOver = false;
    float difficulty;


	void Start () 
    {
        int score = PlayerPrefs.GetInt("MONEY");
        lifetimeScore.text = "Lifetime Score: " + score;
        numLives.text = "NUM LIVES: " + PlayerPrefs.GetInt("NUM_LIVES");
	}
	
    public void GameOver()
    {
        PlayerPrefs.SetInt("NUM_LIVES", PlayerPrefs.GetInt("NUMLIVES") - 1);

        if(PlayerPrefs.GetInt("NUMLIVES") < 0)
        {
            timerBar.SetIsPaused(true);
            scoreBar.SetIsPaused(true); //TODO: make a Pause function
            isGameOver = true;
            PlayerPrefs.SetFloat("DIFFICULTY", .25f);
            gameOverTextParent.SetActive(true);
        }
        else
        {
            Application.LoadLevel(1);
        }
    }

    public void ButtonClicked()
    {
        if (!isGameOver)
        {
            scoreBar.UpdateScore(16);
            int score = PlayerPrefs.GetInt("MONEY");

            PlayerPrefs.SetInt("MONEY", score + 16);

            //Update the lifetime score as well. 
            lifetimeScore.text = "Lifetime Score: " + PlayerPrefs.GetInt("MONEY");
        }
    }
    

    public void UpdateScore()
    {
    
    }

    public void MoveToNextDifficulty()
    {
        difficulty = PlayerPrefs.GetFloat("DIFFICULTY");
    }

    public void MaxScoreAchieved()
    {
        maxScoreTextParent.SetActive(true);
        timerBar.SetIsPaused(true);
        scoreBar.SetIsPaused(true); //TODO: make a Pause function.
    }

    public void MinScoreAchieved()
    {
        myContinueButton.SetActive(true);
    }

    public void ClickedContinueButton()
    {
        //Update the lifetime score by the current score and then hop over to the next level.
        int score = scoreBar.GetScore();

        PlayerPrefs.SetInt("MONEY", PlayerPrefs.GetInt("MONEY") + score);

        Application.LoadLevel(1);
    }


    //================================================================================================
    //Getters and Setters
    //================================================================================================

    public void UpdateScore(int delta)
    {
        scoreBar.UpdateScore(delta);
    }

    public void SetGameOver(bool tBool)
    {
        isGameOver = tBool;
    }

    public bool GetGameOver()
    {
        return isGameOver;
    }
}