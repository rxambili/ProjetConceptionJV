using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MaJ_Traits : MonoBehaviour
{
    public Transform GeneSlotParent;
    public Transform TotalTraitsPanel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SurvivorCardScript[] survivors = GeneSlotParent.GetComponentsInChildren<SurvivorCardScript>();

        List<Trait> traits = new List<Trait>();
        foreach (SurvivorCardScript s in survivors)
        {
            traits.AddRange(s.perso.traits);
        }

        List<Trait> traitsExprimes = new List<Trait>();
        foreach (Trait t in traits)
        {
            if (!traitsExprimes.Contains(t))
            {
                int nbSame = traits.FindAll(trait => trait.name == t.name).Count;
                if (t.nbNeeded <= nbSame)
                {
                    traitsExprimes.Add(t);
                }
            }
        }

        GameManager.instance.currentPlayerTraits = traitsExprimes;
        

        for (int j = 0; j < 4; j++)
        {
            int nbTraits = traitsExprimes.Count;
            if (j < nbTraits)
            {
                TotalTraitsPanel.transform.Find("TraitSlot" + (j + 1)).GetComponent<Text>().text = traitsExprimes[j].name.ToString();
            } else
            {
                TotalTraitsPanel.transform.Find("TraitSlot" + (j + 1)).GetComponent<Text>().text = "";
            }
        }
    }
}
