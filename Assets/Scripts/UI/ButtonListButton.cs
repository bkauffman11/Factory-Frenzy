using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {

    public Text myText;
    public ButtonListButton selfReference;
    private string myTextString;
    public ButtonListControl buttonControl;

    public Image mySprite;

    private int featureID = -1;

	public void SetText(string tString)
    {
        myTextString = tString;
        myText.text = tString;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked(featureID);
    }

    public void setFeatureID(int tFeatureID)
    {
        featureID = tFeatureID;
    }

    public int getFeatureID()
    {
        return featureID;
    }
}
