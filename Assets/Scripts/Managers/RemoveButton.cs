using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButton : MonoBehaviour {

    CharacterCreationManager characterUi;
    void Start()
    {
        characterUi = GetComponentInParent<CharacterCreationManager>();
    }

    public void RemoveButtonGeneSlot(GameObject buttonRemove)
    {
        
        characterUi.RemoveGene(buttonRemove);
    }
}
