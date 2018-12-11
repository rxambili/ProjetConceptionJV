using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeverrouilleSlot : MonoBehaviour {
    public int orbesNeeded = 100;
    public GameObject pauvreTxt;
    public GameObject pasPauvreTxt;
    public Transform AssemblyPanel;
    GameObject pasPauvreTxt1;
    GameObject pauvreTxt1;
    void Start()
    {
        transform.GetComponentInChildren<Text>().text = string.Format("Ajouter un slot\n({0})", orbesNeeded);
    }
    public void deverouilleSlot()
    {
        int orbes = GameManager.instance.nbOrbes;
        if(orbes >= orbesNeeded)
        {
            GameManager.instance.nbSlots++;
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
