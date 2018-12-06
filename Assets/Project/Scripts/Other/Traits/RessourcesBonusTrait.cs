using System.Collections;
using System.Collections.Generic;
using GameProject;
using UnityEngine;

[CreateAssetMenu(fileName = "New ressources bonus trait", menuName = "Trait/Ressources Bonus Trait")]
[System.Serializable]
public class RessourcesBonusTrait : Trait {

    public int bonusAmmo;
    RessourcesManager ressourcesManager;
    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        ressourcesManager = gameObject.GetComponent<RessourcesManager>();
        ressourcesManager.AddBonusAmmo(bonusAmmo);
    }

    public override void UpdateTrait()
    {

    }
}
