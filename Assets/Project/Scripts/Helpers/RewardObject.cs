using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObject : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Reward()
    {
        gameObject.SetActive(true);
    }


}
