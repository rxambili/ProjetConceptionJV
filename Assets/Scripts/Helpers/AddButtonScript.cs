using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonScript : MonoBehaviour {

    CharacterCreationManager characterUi;
	void Start () {
        characterUi = GetComponentInParent<CharacterCreationManager>();
	}
	
	public void AddButton(GameObject buttonAdd)
    {
        characterUi.AjouterGene(buttonAdd);
    }
}
