using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryTellScript : MonoBehaviour {

    public string[] texts;
    public float fade;
    public float textDuration;
    private Text textField;

    private float timer;
    private int currentText = 0;

    private void Awake()
    {
        textField = GetComponent<Text>();
    }
    // Use this for initialization
    void Start () {
        timer = 0;
        currentText = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndStory();
        }

		if (timer == 0)
        {
            textField.text = texts[currentText];
        }

        timer += Time.deltaTime;
        if (timer <= textDuration)
        {
            if (timer <= fade)
            {
                textField.color = Color.Lerp(Color.clear, Color.white, timer / fade);
            }
            if (timer >= textDuration - fade)
            {
                textField.color = Color.Lerp(Color.clear, Color.white, (textDuration - timer) / fade);
            }
        } else
        {
            timer = 0;
            currentText++;
            if (currentText >= texts.Length)
            {
                EndStory();
            }
        }
	}

    private void EndStory()
    {
        SceneManager.LoadScene(2);
    }
}
