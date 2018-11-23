using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats{ 
    
    private static float constitution = 0;
    private static float perception = 0;
    private static float melee = 0;
    private static float tir = 0;
    
    
    public static void SetConstitution(float number)
    {
        constitution = number;
    }

    public static void SetPerception(float number)
    {
        perception = number;
    }

    public static void SetMelee(float number)
    {
        melee = number;
    }

    public static void SetTir(float number)
    {
        tir = number;
    }


    public static float GetConstitution()
    {
        return constitution;
    }

    public static float GetPerception()
    {
        return perception;
    }

    public static float GetMelee()
    {
        return melee;
    }

    public static float GetTir()
    {
        return tir;
    }
}
