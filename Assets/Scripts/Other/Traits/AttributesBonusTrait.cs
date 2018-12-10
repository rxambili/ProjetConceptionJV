using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New attributes bonus trait", menuName = "Trait/Attributes Bonus Trait")]
[System.Serializable]
public class AttributesBonusTrait : Trait {

    // Bonus/Malus en pourcentage
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusPV;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusResistance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusSpeed;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusRadius;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusPeripheralRadius;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusAngle;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusAtkMelee;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusMeleeCriticalChance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusTir;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusTirCriticalChance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] public int bonusReloadSpeed;

    private PlayerAttributesManager playerAttr;

    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        playerAttr = gameObject.GetComponent<PlayerAttributesManager>();
        playerAttr.AddBonusStartingHealth(bonusPV);
        playerAttr.AddBonusResistance(bonusResistance);
        playerAttr.AddBonusSpeed(bonusSpeed);
        playerAttr.AddBonusRadius(bonusRadius);
        playerAttr.AddBonusPeripheralRadius(bonusPeripheralRadius);
        playerAttr.AddBonusAngle(bonusAngle);
        playerAttr.AddBonusAtkMelee(bonusAtkMelee);
        playerAttr.AddBonusMeleeCriticalChance(bonusMeleeCriticalChance);
        playerAttr.AddBonusTir(bonusTir);
        playerAttr.AddBonusReloadSpeed(bonusReloadSpeed);
        playerAttr.AddBonusTirCriticalChance(bonusTirCriticalChance);
    }

    public override void UpdateTrait()
    {
        
    }
}
