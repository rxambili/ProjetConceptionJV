using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

[CreateAssetMenu(fileName = "New colorblind trait", menuName = "Trait/Colorblind Trait")]
[System.Serializable]
public class ColorblindTrait : Trait {

    [SerializeField, Range(1,3)] public int type = 1;

    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Colorblind>().Type = type;
    }

    public override void UpdateTrait()
    {
        
    }

}
