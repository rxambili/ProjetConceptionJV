using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncFOVThirdEyeSpotLight : MonoBehaviour
{

    FieldOfView fov;

    Light spotLight;

    // Use this for initialization
    void Start()
    {
        fov = GetComponentInParent<FieldOfView>();
        spotLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.hasThirdEye)
        {
            spotLight.enabled = true;
            spotLight.range = fov.viewRadiusThirdEye;
            spotLight.spotAngle = fov.viewAngleThirdEye;
        } else
        {
            spotLight.enabled = false;
        }
    }
}
