using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLimitation : MonoBehaviour {

    CharacterCreationManager characterCreationManager;
    Slider slider;

	// Use this for initialization
	void Awake () {
        characterCreationManager = GetComponentInParent<CharacterCreationManager>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(LimitSlider);
    }

    private void LimitSlider(float newValue)
    {
        float pointsRestants = characterCreationManager.GetPointsRestants();
        if (pointsRestants < 0)
        {
            slider.value = newValue + pointsRestants;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
