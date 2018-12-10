using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncFOVPointLight : MonoBehaviour {

    FieldOfView fov;

    Light pointLight;

    // Use this for initialization
    void Start()
    {
        fov = GetComponentInParent<FieldOfView>();
        pointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        pointLight.range = fov.viewRadiusPeripheralVision;
        pointLight.enabled = fov.hasPeripheralVision;
    }
}
