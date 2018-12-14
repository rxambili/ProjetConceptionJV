using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptions : MonoBehaviour {
    public GameObject OptionsPanel;
	public void CloseOptionButton()
    {
        OptionsPanel.SetActive(false);
    }
}
