using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public float constitution { get; set; }
    public float agilite { get; set; }
    public float perception { get; set; }
    public float melee { get; set; }
    public float tir { get; set; }
   
    public Stats()
    {
        Reset();
    }
    public void Reset()
    {
        perception = 0;
        agilite = 0;
        constitution = 0;
        tir = 0;
        melee = 0;
    }
}
