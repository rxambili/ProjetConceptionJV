using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingObject : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Block()
    {
        gameObject.SetActive(true);
    }

    public void Unblock()
    {
        gameObject.SetActive(false);
    }

}
