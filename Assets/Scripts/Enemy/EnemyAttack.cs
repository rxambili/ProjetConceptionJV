﻿using UnityEngine;
using System.Collections;

namespace GameProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
        public int attackDamage = 10;               // The amount of health taken away per attack.
        public float range = 2f;
        public int hitAngle = 90;

        protected Animator anim;                              // Reference to the animator component.
        protected GameObject player;                          // Reference to the player GameObject.
        protected PlayerHealth playerHealth;                  // Reference to the player's health.
        protected EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        protected bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        protected float timer;                                // Timer for counting up to the next attack.


        void Awake ()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the player...
            if(other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
            }
        }


        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.gameObject == player)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }


        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                // ... attack.
                Attack ();
            }

                // If the player has zero or less health...
                if (playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger ("PlayerDead");
            }
        }


        protected virtual void Attack ()
        {
            // Reset the timer.
            timer = 0f;

            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                // animation
                anim.SetTrigger("Attacking");
            }
        }

        protected virtual void InflictDamages()
        {
            // If the player has health to lose and is in range
            if (playerHealth.currentHealth > 0)
            {
                Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                Vector2 targetPos2D = new Vector2(playerTransform.position.x, playerTransform.position.z);
                Vector2 transformPos2D = new Vector2(transform.position.x, transform.position.z);
                Vector2 directionToTarget = targetPos2D - transformPos2D;
                if (Vector2.Angle(new Vector2(transform.forward.x, transform.forward.z), directionToTarget.normalized) < hitAngle / 2)
                {
                    if (Vector2.Distance(targetPos2D, transformPos2D) <= range)
                    {
                        // ... damage the player.
                        playerHealth.TakeDamage(attackDamage);
                    }
                }
            }
        }
    }
}