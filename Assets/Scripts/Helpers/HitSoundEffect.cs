using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundEffect : MonoBehaviour {

    public AudioClip[] audioClips;

    ParticleSystem particles;
    AudioSource audioSource;
    int _numberOfParticles;

    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        var count = particles.particleCount;
        if (count > _numberOfParticles)
        { //particle has been born
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            audioSource.Play();
        }
        _numberOfParticles = count;
    }
}
