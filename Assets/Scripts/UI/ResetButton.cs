using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	public void onResetButtonPushed()
    {
        Application.LoadLevel(1);
    }

}
