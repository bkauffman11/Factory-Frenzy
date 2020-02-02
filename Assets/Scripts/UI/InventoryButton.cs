using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryButton : MonoBehaviour 
{
    public Image myIcon;

    public void SetIcon(Sprite mySprite)
    {
        myIcon.sprite = mySprite;
    }
	
}
