using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New third eye trait", menuName = "Trait/Others/Third Eye Trait")]
[System.Serializable]
public class ThirdEyeTrait : Trait {

    public float viewRadius = 4f;
    public float viewAngle = 70f;

    public override void InitializeTrait(GameObject initGameObject)
    {
        gameObject = initGameObject;
        FieldOfView fov = gameObject.GetComponentInChildren<FieldOfView>();
        fov.hasThirdEye = true;
        fov.viewRadiusThirdEye = viewRadius;
        fov.viewAngleThirdEye = viewAngle;
    }

    public override void UpdateTrait()
    {
        
    }

}
