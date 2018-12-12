using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaJ_nbOrbes : MonoBehaviour {

    public Transform NbOrbesTxt;
	
	// Update is called once per frame
	void Update () {
        NbOrbesTxt.GetComponent<Text>().text = GameManager.instance.nbOrbes.ToString();
    }
}
