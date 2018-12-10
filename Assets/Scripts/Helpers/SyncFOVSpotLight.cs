using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncFOVSpotLight : MonoBehaviour {

    FieldOfView fov;

    Light spotLight;

	// Use this for initialization
	void Start () {
        fov = GetComponentInParent<FieldOfView>();
        spotLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        spotLight.range = fov.viewRadius;
        spotLight.spotAngle = fov.viewAngle;
	}
}
