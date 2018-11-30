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


    public int GetStartingHealth()
    {
        return (int)(basePV + multiplicateurPV * GetConstitution());
    }

    public int GetResistance()
    {
        return (int)(baseResistance + multiplicateurResistance * GetConstitution());
    }

    public float GetSpeed()
    {
        return baseSpeed + multiplicateurSpeed * GetAgilite();
    }

    public float GetRadius()
    {
        return baseRadius + multiplicateurRadius * GetPerception();
    }

    public float GetPeripheralRadius()
    {
        return basePeripheralRadius + multiplicateurPeripheralRadius * GetPerception();
    }

    public float GetAngle()
    {
        return baseAngle + multiplicateurAngle * GetPerception();
    }

    public int GetAtkMelee()
    {
        return (int)(baseMelee + multiplicateurMelee * GetMelee());
    }

    public int GetMeleeCriticalChance()
    {
        return (int)(baseMeleeCriticalChance + multiplicateurMeleeCriticalChance * GetMelee());
    }

    public int GetAtkTir()
    {
        return (int)(baseTir + multiplicateurTir * GetTir());
    }
    public int GetCriticalChance()
    {
        return (int)(baseCriticalChance + multiplicateurCriticalChance * GetTir());
    }


    public float GetReloadSpeed()
    {
        return baseReloadSpeed + multiplicateurReloadSpeed * (factReloadAgi * GetAgilite() + factReloadTir * GetTir());
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
}
