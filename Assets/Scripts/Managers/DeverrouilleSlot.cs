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
        transform.Find("CoutTxt").GetComponent<Text>().text = orbesNeeded.ToString();
    }
    public void deverouilleSlot()
    {
        
        if(GameManager.instance.nbOrbes >= orbesNeeded)
        {
            GameManager.instance.nbSlots++;
            GameManager.instance.nbOrbes -= orbesNeeded;
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
