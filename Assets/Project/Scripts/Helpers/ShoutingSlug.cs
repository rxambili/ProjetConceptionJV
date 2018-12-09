﻿using GameProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutingSlug : StateMachineBehaviour {

    AudioSource audioSource;
    public AudioClip[] audioClips;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<EnemySlugHealth>().isShouting = true;

        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<EnemySlugHealth>().isShouting = true;
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<EnemySlugHealth>().isShouting = false;
        audioSource = animator.GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
        audioSource.Play();
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
