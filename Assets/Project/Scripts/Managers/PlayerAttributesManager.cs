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
        return (int)(basePV + multiplicateurPV * PlayerStats.GetConstitution());
    }

    public float GetSpeed()
    {
        return baseSpeed + multiplicateurSpeed * PlayerStats.GetConstitution();
    }

    public float GetRadius()
    {
        return baseRadius + multiplicateurRadius * PlayerStats.GetPerception();
    }

    public float GetPeripheralRadius()
    {
        return basePeripheralRadius + multiplicateurPeripheralRadius * PlayerStats.GetPerception();
    }

    public float GetAngle()
    {
        return baseAngle + multiplicateurAngle * PlayerStats.GetPerception();
    }

    public int GetAtkMelee()
    {
        return (int)(baseMelee + multiplicateurMelee * PlayerStats.GetMelee());
    }

    public int GetAtkTir()
    {
        return (int)(baseTir + multiplicateurTir * PlayerStats.GetTir());
    }

    public void SetConstitution(float number)
    {
        PlayerStats.SetConstitution(number);
    }

    public void SetPerception(float number)
    {
        PlayerStats.SetPerception(number);
    }

    public void SetMelee(float number)
    {
        PlayerStats.SetMelee(number);
    }

    public void SetTir(float number)
    {
        PlayerStats.SetTir(number);
    }

    public float GetConstitution()
    {
        return PlayerStats.GetConstitution();
    }

    public float GetPerception()
    {
        return PlayerStats.GetPerception();
    }

    public float GetMelee()
    {
        return PlayerStats.GetMelee();
    }

    public float GetTir()
    {
        return PlayerStats.GetTir();
    }
}
