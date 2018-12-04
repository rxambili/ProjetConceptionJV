using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		foreach (Trait t in GameManager.instance.currentPlayerTraits)
        {
            t.InitializeTrait(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Trait t in GameManager.instance.currentPlayerTraits)
        {
            t.UpdateTrait();
        }
    }
}
