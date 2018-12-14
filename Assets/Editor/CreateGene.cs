using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateGene {
    static int id = 0;
    public static Gene Create()
    {
        Gene asset = ScriptableObject.CreateInstance<Gene>();

        AssetDatabase.CreateAsset(asset, "Assets/Gene" + id.ToString() +".asset");
        AssetDatabase.SaveAssets();
        id++;
        return asset;
    }
}
