using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesManager : MonoBehaviour {

    [Header("PV")]
    [SerializeField, Tooltip("PV = Base PV + MultiplicateurPV * Constitution")] private int basePV = 50;
    [SerializeField, Tooltip("PV = Base PV + MultiplicateurPV * Constitution")] private float multiplicateurPV = 10;
    [SerializeField, Tooltip("Resistance = Base Resistance + MultiplicateurResistance * Constitution")] private int baseResistance = 0;
    [SerializeField, Tooltip("Resistance = Base Resistance + MultiplicateurResistance * Constitution")] private float multiplicateurResistance = 1;
    [Space(5)]

    [Header("Mouvement")]
    [SerializeField, Tooltip("Speed = Base Speed + MultiplicateurSpeed * Agilité")] private float baseSpeed = 3;
    [SerializeField, Tooltip("Speed = Base Speed + MultiplicateurSpeed * Agilité")] private float multiplicateurSpeed = 0.7f;

    [Space(5)]

    [Header("Perception")]
    [SerializeField, Tooltip("Radius = Base Radius + MultiplicateurRadius * Perception")] private float baseRadius = 5;
    [SerializeField, Tooltip("Radius = Base Radius + MultiplicateurRadius * Perception")] private float multiplicateurRadius = 1;
    [SerializeField, Tooltip("Angle = Base Angle + MultiplicateurAngle * Perception")] private float baseAngle = 80;
    [SerializeField, Tooltip("Angle = Base Angle + MultiplicateurAngle * Perception")] private float multiplicateurAngle = 10;
    [SerializeField, Tooltip("Peripheral Radius = Base Peripheral Radius + MultiplicateurPeripheralRadius * Perception")] private float basePeripheralRadius = 0.5f;
    [SerializeField, Tooltip("Peripheral Radius = Base Peripheral Radius + MultiplicateurPeripheralRadius * Perception")] private float multiplicateurPeripheralRadius = 0.2f;

    [Header("Mêlée")]
    [SerializeField, Tooltip("Dommages Mêlée = Base Melee + MultiplicateurMelee * atkMelee")] private float baseMelee = 5;
    [SerializeField, Tooltip("Dommages Mêlée = Base Melee + MultiplicateurMelee * atkMelee")] private float multiplicateurMelee = 1;
    [SerializeField, Tooltip("Chances de critique = Base Chances de critique + MultiplicateurCriticalChance * atkMelee")] private int baseMeleeCriticalChance = 1;
    [SerializeField, Tooltip("Chances de critique = Base Chances de critique + MultiplicateurCriticalChance * atkMelee")] private float multiplicateurMeleeCriticalChance = 1;


    [Header("Tir")]
    [SerializeField, Tooltip("Dommages Tir = Base Tir + MultiplicateurTir * atkTir")] private float baseTir = 5;
    [SerializeField, Tooltip("Dommages Tir = Base Tir + MultiplicateurTir * atkTir")] private float multiplicateurTir = 1;
    [SerializeField, Tooltip("Chances de critique = Base Chances de critique + MultiplicateurCriticalChance * atkTir")] private int baseCriticalChance = 1;
    [SerializeField, Tooltip("Chances de critique = Base Chances de critique + MultiplicateurCriticalChance * atkTir")] private float multiplicateurCriticalChance = 1;
    [SerializeField, Tooltip("Reload Speed = Base Reload Speed + MultiplicateurReloadSpeed * (%agi * Agilité + %tir * atkTir)")] private float baseReloadSpeed = 1;
    [SerializeField, Tooltip("Reload Speed = Base Reload Speed + MultiplicateurReloadSpeed * (%agi * Agilité + %tir * atkTir)")] private float multiplicateurReloadSpeed = 0.1f;
    [SerializeField, Range(0, 1), Tooltip("Reload Speed = Base Reload Speed + MultiplicateurReloadSpeed * (%agi * Agilité + %tir * atkTir)")] private float factReloadAgi = 0.5f;
    [SerializeField, Range(0, 1), Tooltip("Reload Speed = Base Reload Speed + MultiplicateurReloadSpeed * (%agi * Agilité + %tir * atkTir)")] private float factReloadTir = 0.5f;

    [Space(5)]
    [Header("Bonus/Malus")]
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusPV;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusResistance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusSpeed;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusRadius;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusPeripheralRadius;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusAngle;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusAtkMelee;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusMeleeCriticalChance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusTir;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusTirCriticalChance;
    [SerializeField, Tooltip("Bonus/Malus en pourcentage")] private int bonusReloadSpeed;

    public int GetStartingHealth()
    {
        return (int)((basePV + multiplicateurPV * GetConstitution()) * Mathf.Max(0f, 1f + bonusPV/100f));
    }

    public int GetResistance()
    {
        return (int)((baseResistance + multiplicateurResistance * GetConstitution()) * Mathf.Max(0f, 1f + bonusResistance / 100f));
    }

    public float GetSpeed()
    {
        return (baseSpeed + multiplicateurSpeed * GetAgilite()) * Mathf.Max(0f, 1f + bonusSpeed / 100f);
    }

    public float GetRadius()
    {
        return (baseRadius + multiplicateurRadius * GetPerception()) * Mathf.Max(0f, 1f + bonusRadius / 100f);
    }

    public float GetPeripheralRadius()
    {
        return (basePeripheralRadius + multiplicateurPeripheralRadius * GetPerception()) * Mathf.Max(0f, 1f + bonusPeripheralRadius / 100f);
    }

    public float GetAngle()
    {
        return (baseAngle + multiplicateurAngle * GetPerception()) * Mathf.Max(0f, 1f + bonusAngle / 100f);
    }

    public int GetAtkMelee()
    {
        return (int)((baseMelee + multiplicateurMelee * GetMelee()) * Mathf.Max(0f, 1f + bonusAtkMelee / 100f));
    }

    public int GetMeleeCriticalChance()
    {
        return (int)((baseMeleeCriticalChance + multiplicateurMeleeCriticalChance * GetMelee()) * Mathf.Max(0f, 1f + bonusMeleeCriticalChance / 100f));
    }

    public int GetAtkTir()
    {
        return (int)((baseTir + multiplicateurTir * GetTir()) * Mathf.Max(0f, 1f + bonusTir / 100f));
    }
    public int GetCriticalChance()
    {
        return (int)((baseCriticalChance + multiplicateurCriticalChance * GetTir()) * Mathf.Max(0f, 1f + bonusTirCriticalChance / 100f));
    }


    public float GetReloadSpeed()
    {
        return (baseReloadSpeed + multiplicateurReloadSpeed * (factReloadAgi * GetAgilite() + factReloadTir * GetTir())) * Mathf.Max(0f, 1f + bonusReloadSpeed / 100f);
    }

    public void SetConstitution(float number)
    {
        GameManager.instance.currentPlayerStats.constitution = number;
    }

    public void SetAgilite(float number)
    {
        GameManager.instance.currentPlayerStats.agilite = number;
    }

    public void SetPerception(float number)
    {
        GameManager.instance.currentPlayerStats.perception = number;
    }

    public void SetMelee(float number)
    {
        GameManager.instance.currentPlayerStats.melee = number;
    }

    public void SetTir(float number)
    {
        GameManager.instance.currentPlayerStats.tir = number;
    }

    public float GetConstitution()
    {
        return GameManager.instance.currentPlayerStats.constitution;
    }

    public float GetAgilite()
    {
        return GameManager.instance.currentPlayerStats.agilite;
    }

    public float GetPerception()
    {
        return GameManager.instance.currentPlayerStats.perception;
    }

    public float GetMelee()
    {
        return GameManager.instance.currentPlayerStats.melee;
    }

    public float GetTir()
    {
        return GameManager.instance.currentPlayerStats.tir;
    }

    public void AddBonusStartingHealth(int amount)
    {
        bonusPV += amount;
    }

    public void AddBonusResistance(int amount)
    {
        bonusResistance += amount;
    }

    public void AddBonusSpeed(int amount)
    {
        bonusSpeed += amount;
    }

    public void AddBonusRadius(int amount)
    {
        bonusRadius += amount;
    }

    public void AddBonusPeripheralRadius(int amount)
    {
        bonusPeripheralRadius += amount;
    }

    public void AddBonusAngle(int amount)
    {
        bonusAngle += amount;
    }

    public void AddBonusAtkMelee(int amount)
    {
        bonusAtkMelee += amount;
    }

    public void AddBonusMeleeCriticalChance(int amount)
    {
        bonusMeleeCriticalChance += amount;
    }

    public void AddBonusTir(int amount)
    {
        bonusTir += amount;
    }

    public void AddBonusReloadSpeed(int amount)
    {
        bonusReloadSpeed += amount;
    }

    public void AddBonusTirCriticalChance(int amount)
    {
        bonusTirCriticalChance += amount;
    }

}
