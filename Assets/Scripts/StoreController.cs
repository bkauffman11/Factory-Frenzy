using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreController : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text purchaseText;


	// Use this for initialization
	void Start () 
    {
        scoreText.text = "MONEY: " + PlayerPrefs.GetInt("MONEY") + "$";
        livesText.text = "Extra Lives: " + PlayerPrefs.GetInt("NUM_LIVES");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickedPlayAgain()
    {
        Application.LoadLevel(1);
    }

    public void ClickedPurchaseButton()
    {
        if(PlayerPrefs.GetInt("MONEY") > 9)
        {
            purchaseText.text = "Got one!";
            PlayerPrefs.SetInt("MONEY", PlayerPrefs.GetInt("MONEY") - 10);
            PlayerPrefs.SetInt("NUM_LIVES", PlayerPrefs.GetInt("NUM_LIVES") + 1);
            livesText.text = "Extra Lives: " + PlayerPrefs.GetInt("NUM_LIVES");
            scoreText.text = "MONEY: " + PlayerPrefs.GetInt("MONEY") + "$";
        }
        else
        {
            purchaseText.text = "Hey, you can't buy that!";
        }
    }
}
