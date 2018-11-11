using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEnemy : MonoBehaviour, IHideable
{


    // Use this for initialization
    void Awake()
    {
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
            m.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFOVEnter()
    {
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
            m.enabled = true;
        }
    }

    public void OnFOVLeave()
    {
        Component[] meshComponents = GetComponentsInChildren(typeof(SkinnedMeshRenderer), true);
        foreach (SkinnedMeshRenderer m in meshComponents)
        {
            m.enabled = false;
        }
    }
}
