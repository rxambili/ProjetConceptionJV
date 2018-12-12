using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotationScript : MonoBehaviour {

    Quaternion fixedRotation;

    private void Start()
    {
        fixedRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = fixedRotation;
    }
}
