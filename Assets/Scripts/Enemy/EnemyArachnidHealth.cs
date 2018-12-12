using UnityEngine;

namespace GameProject
{
    public class EnemyArachnidHealth : EnemyHealth
    {
        
        public float shoutingDamageMult = 2f;

        public bool isShouting { get; set; }

      
        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }
               

        protected override void Death(Vector3 hitDir)
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Tell the animator that the enemy is dead.
            anim.SetTrigger("Dead");

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
                        
            Destroy(gameObject, 2.5f);
            Invoke("SpawnOrbe", 2f);
        }
        
    }
}