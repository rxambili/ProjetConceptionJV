using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour {

    public GameObject OptionsPanel;

    public void OpenOptionPanelButton()
    {
        OptionsPanel.SetActive(true);
    }
}
