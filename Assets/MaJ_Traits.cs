using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MaJ_Traits : MonoBehaviour
{
    public Transform GeneSlotParent;
    int nbChild;
    public Transform TotalTraitsPanel;
    string temp1;
    string temp2;
    int k;

    string[] listTraits = new string[3];
    int cpt1;
    bool first = true;
    int cpt2;
    string name1;
    string name2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        k = cpt1 = cpt2 = 0;
        for (int l = 0; l < 3; l++)
        {
            listTraits[l] = " ";
        }

        nbChild = GeneSlotParent.childCount;

        for (int i = 0; i < nbChild; i++)
        {
            if ((temp1 = GeneSlotParent.GetChild(i).transform.Find("TextParent").Find("Txt5").GetComponent<Text>().text) != "")
            {
                temp2 = temp1.Substring(temp1.Length - 4, 3);
                if (temp2.Substring(0, 1) == temp2.Substring(2, 1))
                {
                    listTraits[k] = "- " + temp1.Substring(0, temp1.Length - 5);
                    k++;
                }
                else
                {
                    //temp1.Substring(0, temp1.Length - 5);

                    if (first)
                    {
                        name1 = temp1.Substring(0, temp1.Length - 5);
                        first = false;
                    }
                    else
                    {
                        name2 = temp1.Substring(0, temp1.Length - 5);
                        if (name1 == name2)
                        {
                            listTraits[k] = "- " + name1;
                            first = true;
                            k++;
                        }

                    }

                }
            }
            for (int j = 0; j < 3; j++)
            {
                TotalTraitsPanel.transform.Find("TraitSlot" + (j + 1)).GetComponent<Text>().text = listTraits[j];
            }

        }
    }
}
