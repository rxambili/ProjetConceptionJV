using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterCreationManager : MonoBehaviour
{
    public PlayerAttributesManager playerAttr;
    public Personnage[] listSurvivants;

    public Transform SurvivorListPanel;
    public GameObject SurvivorCard;

    public Transform GeneSlotParentdeMerde;
    public GameObject prefabGeneSlot;

    Canvas canvas;
    public Text constitutionText;
    public Text perceptionText;
    public Text meleeText;
    public Text tirText;
    public Text pointsText;
    private float pointsRestants = 15f;
    GameObject newSurvivorCard;
    GameObject newGeneSlot;


    /*private void Awake()
    {
        playerAttr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributesManager>();
    }*/

    void Start()
    {
        
        canvas = GetComponent<Canvas>();
        /*constitutionText.text = playerAttr.GetConstitution().ToString("F1");
        perceptionText.text = playerAttr.GetPerception().ToString("F1");
        meleeText.text = playerAttr.GetMelee().ToString("F1");
        tirText.text = playerAttr.GetTir().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);*/
        
        // Generation de la liste des genes des survivants
        for (int i = 0; i < listSurvivants.Length; i++)
        {
            newSurvivorCard = Instantiate(SurvivorCard);
            newSurvivorCard.transform.SetParent(SurvivorListPanel);

            newSurvivorCard.transform.Find("CaracterImg").GetComponent<Image>().sprite = listSurvivants[i].getArtwork();
            newSurvivorCard.transform.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text = listSurvivants[i].getName();
            bool rempli;
            bool P, C, A, T, M;
            P=C=A=T=M= false;
            for(int j = 1; j < 6; j++)
            {
                rempli = false;
                if (listSurvivants[i].genome[0].bonusPerception != 0 && !rempli && !P)
                {
                    P = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt"+j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusPerception.ToString()+ "  Perception";
                }
                if (listSurvivants[i].genome[0].bonusConstitution != 0 && !rempli && !C)
                {
                    C = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusConstitution.ToString() + "  Constitution";
                }
                if (listSurvivants[i].genome[0].bonusAgilite != 0 && !rempli && !A)
                {
                    A = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusAgilite.ToString() + "  Agilite";
                }   
                if (listSurvivants[i].genome[0].bonusTir != 0 && !rempli && !T)
                {
                    T = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusTir.ToString() + "  Tir";
                }
                if (listSurvivants[i].genome[0].bonusMelee != 0 && !rempli && !M)
                {
                    M = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusMelee.ToString() + "  Melee";
                }
              

            }

        }
       
    }

    public void Validate()
    {
        SceneManager.LoadScene(1);
    }

    public void SetConstitution(float number)
    {
        float diff = number - playerAttr.GetConstitution();
        pointsRestants -= diff;
        playerAttr.SetConstitution(number);
        constitutionText.text = playerAttr.GetConstitution().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetPerception(float number)
    {
        float diff = number - playerAttr.GetPerception();
        pointsRestants -= diff;
        playerAttr.SetPerception(number);
        perceptionText.text = playerAttr.GetPerception().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetMelee(float number)
    {
        float diff = number - playerAttr.GetMelee();
        pointsRestants -= diff;
        playerAttr.SetMelee(number);
        meleeText.text = playerAttr.GetMelee().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public void SetTir(float number)
    {
        float diff = number - playerAttr.GetTir();
        pointsRestants -= diff;
        playerAttr.SetTir(number);
        tirText.text = playerAttr.GetTir().ToString("F1");
        pointsText.text = string.Format("Points Restant : {0:F1}", pointsRestants);
    }

    public float GetPointsRestants()
    {
        return pointsRestants;
    }



    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
   

    public void AjouterGene(GameObject buttonAdd)
    {
        Debug.Log("GeneSlotParentdeMerde : " + GeneSlotParentdeMerde);
        string name;
        Sprite caracterImg;
  
        Transform currentSurvivorCard = buttonAdd.transform.parent;
        name = currentSurvivorCard.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text;
        caracterImg = currentSurvivorCard.Find("CaracterImg").GetComponent<Image>().sprite;
        
     

        newGeneSlot = Instantiate(prefabGeneSlot);
        
        newGeneSlot.transform.SetParent(GeneSlotParentdeMerde);
        
       




       newGeneSlot.transform.Find("CaracterImg").GetComponent<Image>().sprite = caracterImg;
        newGeneSlot.transform.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text = name;
        newGeneSlot.transform.Find("TextParent").Find("Txt1").GetComponent<Text>().text = currentSurvivorCard.Find("TextParent").Find("Txt1").GetComponent<Text>().text; 
        newGeneSlot.transform.Find("TextParent").Find("Txt2").GetComponent<Text>().text = currentSurvivorCard.Find("TextParent").Find("Txt2").GetComponent<Text>().text;
        newGeneSlot.transform.Find("TextParent").Find("Txt3").GetComponent<Text>().text = currentSurvivorCard.Find("TextParent").Find("Txt3").GetComponent<Text>().text;
        newGeneSlot.transform.Find("TextParent").Find("Txt4").GetComponent<Text>().text = currentSurvivorCard.Find("TextParent").Find("Txt4").GetComponent<Text>().text;
        newGeneSlot.transform.Find("TextParent").Find("Txt5").GetComponent<Text>().text = currentSurvivorCard.Find("TextParent").Find("Txt5").GetComponent<Text>().text;


    }

}
