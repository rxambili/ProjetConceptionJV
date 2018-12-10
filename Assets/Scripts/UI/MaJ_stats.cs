using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaJ_stats : MonoBehaviour {

    public Transform GeneSlotParent;
    int nbChild;
    public Transform TotalStatsPanel;

    Stats currentPlayerStats;

	// Use this for initialization
	void Start () {
        currentPlayerStats = GameManager.instance.currentPlayerStats;

    }
	
	// Update is called once per frame
	void Update () {
        currentPlayerStats.Reset();
        SurvivorCardScript[] survivors = GeneSlotParent.GetComponentsInChildren<SurvivorCardScript>();
        float perception = 0;
        float constitution = 0;
        float agilite = 0;
        float tir = 0;
        float melee = 0;
        foreach (SurvivorCardScript s in survivors)
        {
            Gene gene = s.perso.genome[0];

            perception += gene.bonusPerception;
            constitution += gene.bonusConstitution;
            agilite += gene.bonusAgilite;
            tir += gene.bonusTir;
            melee += gene.bonusMelee;

        }

        currentPlayerStats.perception = Mathf.Max(0f, perception);
        currentPlayerStats.constitution = Mathf.Max(0f, constitution);
        currentPlayerStats.agilite = Mathf.Max(0f, agilite);
        currentPlayerStats.tir = Mathf.Max(0f, tir);
        currentPlayerStats.melee = Mathf.Max(0f, melee);

        TotalStatsPanel.Find("PerceptionTxt").Find("PerceptionTot").GetComponent<Text>().text = currentPlayerStats.perception.ToString();
        TotalStatsPanel.Find("ConstitutionTxt").Find("ConstitutionTot").GetComponent<Text>().text = currentPlayerStats.constitution.ToString();
        TotalStatsPanel.Find("AgiliteTxt").Find("AgiliteTot").GetComponent<Text>().text = currentPlayerStats.agilite.ToString();
        TotalStatsPanel.Find("TirTxt").Find("TirTot").GetComponent<Text>().text = currentPlayerStats.tir.ToString();
        TotalStatsPanel.Find("MeleeTxt").Find("MeleeTot").GetComponent<Text>().text = currentPlayerStats.melee.ToString();
    }
}
