using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesManager : MonoBehaviour {

    [Header("PV")]
    [SerializeField, Tooltip("PV = Base PV + MultiplicateurPV * Constitution")] private int basePV = 50;
    [SerializeField, Tooltip("PV = Base PV + MultiplicateurPV * Constitution")] private float multiplicateurPV = 10;

    [Space(5)]

    [Header("Mouvement")]
    [SerializeField, Tooltip("Speed = Base Speed + MultiplicateurSpeed * Constitution")] private float baseSpeed = 3;
    [SerializeField, Tooltip("Speed = Base Speed + MultiplicateurSpeed * Constitution")] private float multiplicateurSpeed = 0.7f;

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

    [Header("Tir")]
    [SerializeField, Tooltip("Dommages Tir = Base Tir + MultiplicateurTir * atkTir")] private float baseTir = 5;
    [SerializeField, Tooltip("Dommages Tir = Base Tir + MultiplicateurTir * atkTir")] private float multiplicateurTir = 1;


    public int GetStartingHealth()
    {
        return (int)(basePV + multiplicateurPV * GameManager.instance.currentPlayerStats.constitution);
    }

    public float GetSpeed()
    {
        return baseSpeed + multiplicateurSpeed * GameManager.instance.currentPlayerStats.constitution;
    }

    public float GetRadius()
    {
        return baseRadius + multiplicateurRadius * GameManager.instance.currentPlayerStats.perception;
    }

    public float GetPeripheralRadius()
    {
        return basePeripheralRadius + multiplicateurPeripheralRadius * GameManager.instance.currentPlayerStats.perception;
    }

    public float GetAngle()
    {
        return baseAngle + multiplicateurAngle * GameManager.instance.currentPlayerStats.perception;
    }

    public int GetAtkMelee()
    {
        return (int)(baseMelee + multiplicateurMelee * GameManager.instance.currentPlayerStats.melee);
    }

    public int GetAtkTir()
    {
        return (int)(baseTir + multiplicateurTir * GameManager.instance.currentPlayerStats.tir);
    }

    public void SetConstitution(float number)
    {
        GameManager.instance.currentPlayerStats.constitution = number;
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
