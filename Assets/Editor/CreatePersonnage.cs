using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatePersonnage {

    public static Personnage Create()
    {
        Personnage asset = ScriptableObject.CreateInstance<Personnage>();

        AssetDatabase.CreateAsset(asset, "Assets/Personnage.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
