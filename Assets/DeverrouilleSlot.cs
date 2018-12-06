using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeverrouilleSlot : MonoBehaviour {
    public int orbes = 1500;
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
        if(orbes >= 1500)
        {
            characterUi.nbSlot++;
            orbes -= 1500;
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
