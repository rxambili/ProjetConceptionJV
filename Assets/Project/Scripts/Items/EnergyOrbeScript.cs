using GameProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrbeScript : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;
    public int amount;

    ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;
    RessourcesManager playerRessources;

	void Start ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren <ParticleSystem>();
        playerRessources = GameObject.FindGameObjectWithTag("Player").GetComponent<RessourcesManager>();

        var main = ps.main;
        main.duration = spawnEffectTime;

        ps.Play();

    }
	
	void Update ()
    {
        if (timer < spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }

        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerRessources.AddOrbe(amount);
            Destroy(gameObject);
        }
    }
}
