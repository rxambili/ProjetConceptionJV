using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEnemy : IHideable
{
   
    void Awake()
    {
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
            m.enabled = false;
        }
    }


    public override void OnFOVEnter()
    {
        base.OnFOVEnter();
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
           m.enabled = true;
        }
       
    }

    public override void OnFOVLeave()
    {
        base.OnFOVLeave();
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
            m.enabled = false;
        }
    }
}
