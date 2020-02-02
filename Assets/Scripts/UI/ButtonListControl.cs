using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonListControl : MonoBehaviour 
{
    public GameObject buttonTemplate;
    public Sprite[] sorterIcons;
    public GameController gameController;

    void Start()
    {
        GenButtons(6); //6 = one dummy button and five real ones. 
    }


    public void ButtonClicked(int featureID)
    {
        gameController.ButtonClicked();
    }

    public void GenButtons(int numButtons)
    {
        for (int i = 1; i < numButtons; i++)
        {
            GameObject button = Instantiate(buttonTemplate as GameObject);
            button.SetActive(true); //activate the button to acces the script attached

            button.GetComponent<ButtonListButton>().SetText("ID#:" + i);

            button.GetComponent<Image>().sprite = sorterIcons[Random.Range(0, sorterIcons.Length)];

            button.transform.SetParent(buttonTemplate.transform.parent, true);

            button.GetComponent<ButtonListButton>().setFeatureID(i);
        }
    }
}
