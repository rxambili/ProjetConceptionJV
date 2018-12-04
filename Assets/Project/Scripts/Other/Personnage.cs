using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Perso", menuName = "Personnage")]
public class Personnage : ScriptableObject{

    public new string name;
    public string description;
    public int age;
    public Sprite artwork;
    [SerializeField] public List<Gene> genome = new List<Gene>();
    [SerializeField] public Trait[] traits;

    private Stats stats = new Stats();
    private bool isDirty = true;
    
    public void AddGene(Gene g)
    {
        genome.Add(g);
        isDirty = true;
    }

    public Gene GetGeneByIndex(int index)
    {
        return genome.Find(g => genome.IndexOf(g) == index);
    }

    public Stats GetStats()
    {
         if (isDirty)
         {
             ComputeStats();
            isDirty = false;
         }
         return stats;
    }

    public void ComputeStats()
    {
        stats.Reset();
        genome.ForEach(g =>
        {
            stats.perception = stats.perception + g.bonusPerception;
            stats.agilite = stats.agilite + g.bonusAgilite;
            stats.constitution = stats.constitution + g.bonusConstitution;
            stats.tir = stats.tir + g.bonusTir;
            stats.melee = stats.melee + g.bonusMelee;
        });
    }
    public Sprite getArtwork()
    {
        return this.artwork;
    }
    public string getName()
    {
        return this.name;
    }
    
}
