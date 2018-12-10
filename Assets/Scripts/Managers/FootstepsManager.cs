using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour {

    public AudioClip[] grassFootsteps;
    public AudioSource footAudioSource;


    public void PlayFootstep () {
        if (footAudioSource.isPlaying)
        {
            footAudioSource.Stop();
        }
        footAudioSource.clip = grassFootsteps[Random.Range(0,grassFootsteps.Length-1)];
        footAudioSource.Play();
    }
}
