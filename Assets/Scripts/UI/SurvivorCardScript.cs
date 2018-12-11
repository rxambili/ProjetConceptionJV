using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorCardScript : MonoBehaviour {

    public Personnage perso { get; set; }

    // Use this for initialization
    void Start()
    {
        transform.Find("CaracterImg").GetComponent<Image>().sprite = perso.getArtwork();
        transform.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text = perso.getName();
        transform.Find("TextParent").Find("Txt5").GetComponent<Text>().text = string.Format("{0} (1/{1})", perso.traits[0].name, perso.traits[0].nbNeeded);
        bool rempli;
        bool P, C, A, T, M;
        P = C = A = T = M = false;
        for (int j = 1; j < 5; j++)
        {
            rempli = false;
            if (perso.genome[0].bonusPerception != 0 && !rempli && !P)
            {
                rempli = true;
                P = true;
                string symbole = perso.genome[0].bonusPerception < 0 ? "" : "+";
                transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = string.Format("{0}{1} perception", symbole, perso.genome[0].bonusPerception.ToString());
            }
            if (perso.genome[0].bonusConstitution != 0 && !rempli && !C)
            {
                rempli = true;
                C = true;
                string symbole = perso.genome[0].bonusConstitution < 0 ? "" : "+";
                transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = string.Format("{0}{1} constitution", symbole, perso.genome[0].bonusConstitution.ToString());
            }
            if (perso.genome[0].bonusAgilite != 0 && !rempli && !A)
            {
                rempli = true;
                A = true;
                string symbole = perso.genome[0].bonusAgilite < 0 ? "" : "+";
                transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = string.Format("{0}{1} agilite", symbole, perso.genome[0].bonusAgilite.ToString());
            }
            if (perso.genome[0].bonusTir != 0 && !rempli && !T)
            {
                rempli = true;
                T = true;
                string symbole = perso.genome[0].bonusTir < 0 ? "" : "+";
                transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = string.Format("{0}{1} tir", symbole, perso.genome[0].bonusTir.ToString());
            }
            if (perso.genome[0].bonusMelee != 0 && !rempli && !M)
            {
                rempli = true;
                M = true;
                string symbole = perso.genome[0].bonusMelee < 0 ? "" : "+";
                transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = string.Format("{0}{1} melee", symbole, perso.genome[0].bonusMelee.ToString());
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
