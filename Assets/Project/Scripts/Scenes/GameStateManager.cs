using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public SubScene startingSubScene;

    private SubScene currentSubScene;

	// Use this for initialization
	void Start () {
        startingSubScene.Enter();
        currentSubScene = startingSubScene;
	}
	
	public void ChangeState(SubScene subScene) {
        currentSubScene.Exit();
        subScene.Enter();
        currentSubScene = subScene;
    }
}
