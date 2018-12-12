using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnPause : MonoBehaviour {
    public GameObject MenuCanvas;
	
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
        {
            MenuCanvas.SetActive(true);
        }
        else
        {
            MenuCanvas.SetActive(false);
        }
	}
}
