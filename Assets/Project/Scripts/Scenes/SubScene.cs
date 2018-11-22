using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubScene : MonoBehaviour {

    public virtual void Enter() {
        Debug.Log("yo");
        gameObject.SetActive(true);
    }

    public virtual void Exit() {
        gameObject.SetActive(false);
    }
}
