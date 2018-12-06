using System.Collections;
using System.Collections.Generic;
using GameProject;
using UnityEngine;

[CreateAssetMenu(fileName = "New backpedal trait", menuName = "Trait/Backpedal Trait")]
[System.Serializable]
public class BackpedalTrait : Trait {

   [Range(0,1)] public float backpedalFactor = 0f;

    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
        movement.backpedalFactor = backpedalFactor;
    }

    public override void UpdateTrait()
    {
        
    }

}
