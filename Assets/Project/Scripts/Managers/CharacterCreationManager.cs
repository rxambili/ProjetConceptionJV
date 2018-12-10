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
    Personnage[] listSurvivants;
    

    public Transform SurvivorListPanel;
    public GameObject SurvivorCard;

    public Transform GeneSlotParentdeMerde;
    public GameObject prefabGeneSlot;
    public Transform AssemblyPanel;
    Canvas canvas;
    public Text constitutionText;
    public Text perceptionText;
    public Text meleeText;
    public Text tirText;
    public Text pointsText;
    private float pointsRestants = 15f;
    GameObject newSurvivorCard;
    GameObject newGeneSlot;

    public GameObject ErrMsg;
    GameObject newErrMsg;

    //Traits
    public Trait Achromatopsie;
    public Trait CoeurDeBoeuf;
    public Trait Collecteur;
    public Trait Combattant;
    public Trait Daltonien1;
    public Trait Daltonien2;
    public Trait Daltonien3;
    public Trait Fragile;
    public Trait MauvaisCollecteur;
    public Trait Myope;
    public Trait OeilDeFaucon;
    public Trait Sourd;
    public Trait PeauDure;
    public Trait Rechargement;
    public Trait TireurElite;
    public Trait EyeBack;
    public Trait Moonwalker;
    public Trait MouDuCul;
    Trait[] AllTraits = new Trait[18]; 



    public int nbSlot;
    int cptSlot;

    /*private void Awake()
    {
        playerAttr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributesManager>();
    }*/

    void Start()
    {

        listSurvivants = GameManager.instance.survivants;
        nbSlot = 3;
        cptSlot = 0;

        AllTraits[0] = Achromatopsie;
        AllTraits[1] = CoeurDeBoeuf;
        AllTraits[2] = Collecteur;
        AllTraits[3] = Combattant;
        AllTraits[4] = Daltonien1;
        AllTraits[5] = Fragile;
        AllTraits[6] = MauvaisCollecteur;
        AllTraits[7] = Myope;
        AllTraits[8] = OeilDeFaucon;
        AllTraits[9] = Sourd;
        AllTraits[10] = PeauDure;
        AllTraits[11] = Rechargement;
        AllTraits[12] = TireurElite;
        AllTraits[13] = EyeBack;
        AllTraits[14] = MouDuCul;
        AllTraits[15] = Moonwalker;
        AllTraits[16] = Daltonien2;
        AllTraits[17] = Daltonien3;


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
            newSurvivorCard.transform.Find("TextParent").Find("Txt5").GetComponent<Text>().text = listSurvivants[i].traits[0].name + "(1/"+ listSurvivants[i].traits[0].nbNeeded+")";
            bool rempli;
            bool P, C, A, T, M;
            P=C=A=T=M= false;
            for (int j = 1; j < 5; j++)
            {
                rempli = false;
                if (listSurvivants[i].genome[0].bonusPerception != 0 && !rempli && !P)
                {
                    rempli = true;
                    P = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusPerception.ToString()+ "  Perception";
                }
                if (listSurvivants[i].genome[0].bonusConstitution != 0 && !rempli && !C)
                {
                    rempli = true;
                    C = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusConstitution.ToString() + "  Constitution";
                }
                if (listSurvivants[i].genome[0].bonusAgilite != 0 && !rempli && !A)
                {
                    rempli = true;
                    A = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusAgilite.ToString() + "  Agilite";
                }   
                if (listSurvivants[i].genome[0].bonusTir != 0 && !rempli && !T)
                {
                    rempli = true;
                    T = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusTir.ToString() + "  Tir";
                }
                if (listSurvivants[i].genome[0].bonusMelee != 0 && !rempli && !M)
                {
                    rempli = true;
                    M = true;
                    newSurvivorCard.transform.Find("TextParent").Find("Txt" + j).GetComponent<Text>().text = "+" + listSurvivants[i].genome[0].bonusMelee.ToString() + "  Melee";
                }
              

            }

        }
       
    }
    private void Update()
    {
        AssemblyPanel.transform.Find("TxtNbSlotRestant").GetComponent<Text>().text = "Nombre de slots restants : " + (nbSlot - cptSlot);
    }

    public void Validate()
    {
        //STATS
        Transform StatsPanel = AssemblyPanel.transform.Find("TotalStatsPanel");
        playerAttr.SetPerception(float.Parse(StatsPanel.Find("PerceptionTxt").Find("PerceptionTot").GetComponent<Text>().text));
        playerAttr.SetConstitution(float.Parse(StatsPanel.Find("ConstitutionTxt").Find("ConstitutionTot").GetComponent<Text>().text));
        playerAttr.SetAgilite(float.Parse(StatsPanel.Find("AgiliteTxt").Find("AgiliteTot").GetComponent<Text>().text));
        playerAttr.SetTir(float.Parse(StatsPanel.Find("TirTxt").Find("TirTot").GetComponent<Text>().text));
        playerAttr.SetMelee(float.Parse(StatsPanel.Find("MeleeTxt").Find("MeleeTot").GetComponent<Text>().text));
        //TRAITS
        Transform TraitsPanel = AssemblyPanel.transform.Find("TotalTraitsPanel");
        string trait;
        int num = 0;
        for(int w = 1; w < 5; w++)
        {
            if((trait = TraitsPanel.Find("TraitSlot" + w).GetComponent<Text>().text) != "")
            {
                trait = trait.Substring(2);
                for (int n = 0; n < AllTraits.Length; n++)
                {
                    if (trait == AllTraits[n].name)
                    {
                        GameManager.instance.currentPlayerTraits[num] = AllTraits[n];
                        num++;
                    }
                }
            }

        }
        
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
        if (cptSlot >= nbSlot)
        {
           
            newErrMsg = Instantiate(ErrMsg, AssemblyPanel);
            Destroy(newErrMsg, 2);

        }
        else
        {
            
        
            cptSlot++;

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
            Destroy(currentSurvivorCard.gameObject, 0);
        }
    }
    public void RemoveGene(GameObject buttonRemove)
    {
        cptSlot--;
        
        string name;
        Sprite caracterImg;
        
        Transform currentGeneSlot = buttonRemove.transform.parent;


        name = currentGeneSlot.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text;
        
        caracterImg = currentGeneSlot.Find("CaracterImg").GetComponent<Image>().sprite;

        newSurvivorCard = Instantiate(SurvivorCard);
        newSurvivorCard.transform.SetParent(SurvivorListPanel);

        newSurvivorCard.transform.Find("CaracterImg").GetComponent<Image>().sprite = caracterImg;
        newSurvivorCard.transform.Find("SurvivantNameImg").Find("SurvivantName").GetComponent<Text>().text = name;
        newSurvivorCard.transform.Find("TextParent").Find("Txt1").GetComponent<Text>().text = currentGeneSlot.Find("TextParent").Find("Txt1").GetComponent<Text>().text;
        newSurvivorCard.transform.Find("TextParent").Find("Txt2").GetComponent<Text>().text = currentGeneSlot.Find("TextParent").Find("Txt2").GetComponent<Text>().text;
        newSurvivorCard.transform.Find("TextParent").Find("Txt3").GetComponent<Text>().text = currentGeneSlot.Find("TextParent").Find("Txt3").GetComponent<Text>().text;
        newSurvivorCard.transform.Find("TextParent").Find("Txt4").GetComponent<Text>().text = currentGeneSlot.Find("TextParent").Find("Txt4").GetComponent<Text>().text;
        newSurvivorCard.transform.Find("TextParent").Find("Txt5").GetComponent<Text>().text = currentGeneSlot.Find("TextParent").Find("Txt5").GetComponent<Text>().text;
        Destroy(currentGeneSlot.gameObject,0);
    }
    
}


