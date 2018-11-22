using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [Header("Stats")]
    [Range(0, 10)]
    [SerializeField, Tooltip("Constitution du joueur")] private float constitution = 0;
    [Range(0, 10)]
    [SerializeField, Tooltip("Perception du joueur")] private float perception = 0;
    [Range(0, 10)]
    [SerializeField, Tooltip("Compétences en mêlée du joueur")] private float melee = 0;
    [Range(0, 10)]
    [SerializeField, Tooltip("Compétences en tir du joueur")] private float tir = 0;

    [Space(10)]

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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetStartingHealth()
    {
        return (int) (basePV + multiplicateurPV * constitution);
    }

    public float GetSpeed()
    {
        return baseSpeed + multiplicateurSpeed * constitution;
    }

    public float GetRadius()
    {
        return baseRadius + multiplicateurRadius * perception;
    }

    public float GetPeripheralRadius()
    {
        return basePeripheralRadius + multiplicateurPeripheralRadius * perception;
    }

    public float GetAngle()
    {
        return baseAngle + multiplicateurAngle * perception;
    }

    public int GetAtkMelee()
    {
        return (int) (baseMelee + multiplicateurMelee * melee);
    }

    public int GetAtkTir()
    {
        return (int) (baseTir + multiplicateurTir * tir);
    }

    public void SetConstitution(float number)
    {
        constitution = number;
    }

    public void SetPerception(float number)
    {
        perception = number;
    }

    public void SetMelee(float number)
    {
        melee = number;
    }

    public void SetTir(float number)
    {
        tir = number;
    }


    public float GetConstitution()
    {
        return constitution;
    }

    public float GetPerception()
    {
        return perception;
    }

    public float GetMelee()
    {
        return melee;
    }

    public float GetTir()
    {
        return tir;
    }
}
