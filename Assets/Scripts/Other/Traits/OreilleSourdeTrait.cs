using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New oreille sourde trait", menuName = "Trait/Oreille sourde Trait")]
[System.Serializable]
public class OreilleSourdeTrait : Trait
{
    public bool left;

    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        
    }

    public override void UpdateTrait()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audioSources)
        {
            a.panStereo = left ? -1f : 1f;
            a.spatialBlend = 0f;
        }
    }
}
