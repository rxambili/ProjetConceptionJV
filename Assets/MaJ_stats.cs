using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaJ_stats : MonoBehaviour {

    public Transform GeneSlotParent;
    int nbChild;
    public Transform TotalStatsPanel;

    int bonusPerception, bonusConstitution, bonusAgilite, bonusTir, bonusMelee;
    string temp;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        nbChild = GeneSlotParent.childCount;
        
        for (int i = 0; i < nbChild; i++)
        {
            for(int j = 1; j < 5; j++)
            {
                if ((temp = GeneSlotParent.GetChild(i).transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text) != "")
                {
                    if (temp.Contains("Perception"))
                    {
                        bonusPerception += int.Parse(temp.Substring(1, 2));
                    }
                    if (temp.Contains("Constitution"))
                    {
                        bonusConstitution += int.Parse(temp.Substring(1, 2));
                    }
                    if (temp.Contains("Agilite"))
                    {
                        bonusAgilite += int.Parse(temp.Substring(1, 2));
                    }
                    if (temp.Contains("Tir"))
                    {
                        bonusTir += int.Parse(temp.Substring(1, 2));
                    }
                    if (temp.Contains("Melee"))
                    {
                        bonusMelee += int.Parse(temp.Substring(1, 2));
                    }
                }
            }
            


        }
        TotalStatsPanel.Find("PerceptionTxt").Find("PerceptionTot").GetComponent<Text>().text = bonusPerception.ToString();
        TotalStatsPanel.Find("ConstitutionTxt").Find("ConstitutionTot").GetComponent<Text>().text = bonusConstitution.ToString();
        TotalStatsPanel.Find("AgiliteTxt").Find("AgiliteTot").GetComponent<Text>().text = bonusAgilite.ToString();
        TotalStatsPanel.Find("TirTxt").Find("TirTot").GetComponent<Text>().text = bonusTir.ToString();
        TotalStatsPanel.Find("MeleeTxt").Find("MeleeTot").GetComponent<Text>().text = bonusMelee.ToString();
        bonusPerception = bonusConstitution = bonusAgilite = bonusTir = bonusMelee = 0;
    }
}
