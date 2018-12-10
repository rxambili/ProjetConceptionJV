using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[CreateAssetMenu(fileName = "New achromatopsie trait", menuName = "Trait/Achromatopsie Trait")]
[System.Serializable]
public class AchromatopsieTrait : Trait {
    
    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Grayscale>().enabled = true;
    }

    public override void UpdateTrait()
    {
        
    }

}
