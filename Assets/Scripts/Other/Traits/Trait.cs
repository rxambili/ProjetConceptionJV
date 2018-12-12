using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Trait : ScriptableObject {

    public new string name;
    public string description = "Sans Description";
    public int nbNeeded = 1;
    protected GameObject gameObject;

    public abstract void InitializeTrait(GameObject gameObject);

    public abstract void UpdateTrait();

}
