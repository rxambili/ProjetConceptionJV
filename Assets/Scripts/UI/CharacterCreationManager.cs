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

    Personnage[] listSurvivants;    

    public Transform SurvivorListPanel;
    public GameObject SurvivorCard;

    public Transform GeneSlotParent;
    public GameObject prefabGeneSlot;
    public Transform AssemblyPanel;
    GameObject newSurvivorCard;
    GameObject newGeneSlot;

    public GameObject ErrMsg;
    GameObject newErrMsg;
    
    public int nbSlot;
    int cptSlot;


    void Start()
    {

        listSurvivants = GameManager.instance.survivants;
        nbSlot = 3;
        cptSlot = 0;

        // Generation de la liste des genes des survivants
        for (int i = 0; i < listSurvivants.Length; i++)
        {
            newSurvivorCard = Instantiate(SurvivorCard);
            newSurvivorCard.transform.SetParent(SurvivorListPanel);
            newSurvivorCard.GetComponent<SurvivorCardScript>().perso = listSurvivants[i];

        }
       
    }
    private void Update()
    {
        AssemblyPanel.transform.Find("TxtNbSlotRestant").GetComponent<Text>().text = "Nombre de slots restants : " + (nbSlot - cptSlot);
    }

    public void Validate()
    {
        SceneManager.LoadScene(1);
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
            
            Transform currentSurvivorCard = buttonAdd.transform.parent;

            Personnage currentPerso = currentSurvivorCard.GetComponent<SurvivorCardScript>().perso;
            newGeneSlot = Instantiate(prefabGeneSlot);
            newGeneSlot.transform.SetParent(GeneSlotParent);
            newGeneSlot.GetComponent<SurvivorCardScript>().perso = currentPerso;

            Destroy(currentSurvivorCard.gameObject, 0);
        }
    }
    public void RemoveGene(GameObject buttonRemove)
    {
        cptSlot--;
                
        Transform currentGeneSlot = buttonRemove.transform.parent;

        Personnage currentPerso = currentGeneSlot.GetComponent<SurvivorCardScript>().perso;

        newSurvivorCard = Instantiate(SurvivorCard);
        newSurvivorCard.transform.SetParent(SurvivorListPanel);
        newSurvivorCard.GetComponent<SurvivorCardScript>().perso = currentPerso;

        Destroy(currentGeneSlot.gameObject,0);
    }
    
}


