using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeverrouilleSlot : MonoBehaviour {
    public int orbesNeeded = 100;
    public GameObject pauvreTxt;
    public GameObject pasPauvreTxt;
    public Transform AssemblyPanel;
    GameObject pasPauvreTxt1;
    GameObject pauvreTxt1;
    CharacterCreationManager characterUi;
    void Start()
    {
        characterUi = GetComponentInParent<CharacterCreationManager>();
    }
    public void deverouilleSlot()
    {
        int orbes = GameManager.instance.nbOrbes;
        if(orbes >= orbesNeeded)
        {
            characterUi.nbSlot++;
            orbes -= orbesNeeded;
            pasPauvreTxt1 = Instantiate(pasPauvreTxt, AssemblyPanel);
            Destroy(pasPauvreTxt1, 2);
        }
        else
        {
            pauvreTxt1 = Instantiate(pauvreTxt, AssemblyPanel);
            Destroy(pauvreTxt1, 2);
        }
    }
}
