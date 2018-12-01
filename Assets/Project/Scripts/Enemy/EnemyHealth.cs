using UnityEngine;

namespace GameProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 100;            // The amount of health the enemy starts the game with.
        public int currentHealth;                   // The current health the enemy has.
        //public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
        public AudioClip deathClip;                 // The sound to play when the enemy dies.
        public AudioClip hurtClip;
        public AudioSource enemyAudio;
        public int deathIntensity;
        public GameObject head;
        public ParticleSystem criticalDeathParticles;
        public ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.


        Animator anim;                              // Reference to the animator.
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        bool isDead;                                // Whether the enemy is dead.
        


        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }

        private void Start()
        {
            SetKinematic(true);
        }


        public void TakeDamage (int amount, Vector3 hitPoint, Vector3 hitDir)
        {
            // If the enemy is dead...
            if(isDead)
                // ... no need to take damage so exit the function.
                return;

            anim.SetTrigger("Hit");
            // Play the hurt sound effect.
            if (enemyAudio.isPlaying)
            {
                enemyAudio.Stop();
            }
            enemyAudio.clip = hurtClip;
            enemyAudio.Play ();

            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;
            
            // Set the position of the particle system to where the hit was sustained.
            hitParticles.transform.position = hitPoint;

            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if(currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death (hitDir);
            }
        }

        public void TakeCriticalDamage(Vector3 hitDir)
        {
            // If the enemy is dead...
            if (isDead)
                // ... no need to take damage so exit the function.
                return;

            
            currentHealth = 0;
            
            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if (currentHealth <= 0)
            {
                // ... the enemy is dead.
                CriticalDeath(hitDir);
            }
        }

        public void TakeDamage(int amount)
        {
            // If the enemy is dead...
            if (isDead)
                // ... no need to take damage so exit the function.
                return;

            anim.SetTrigger("Hit");
            // Play the hurt sound effect.
            if (enemyAudio.isPlaying)
            {
                enemyAudio.Stop();
            }
            enemyAudio.clip = hurtClip;
            enemyAudio.Play();

            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;

            
            // And play the particles.
            hitParticles.Play();
            

            // If the current health is less than or equal to zero...
            if (currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death( Vector3.zero);
            }
        }

        void CriticalDeath(Vector3 hitDir)
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Tell the animator that the enemy is dead.
            // anim.SetTrigger ("Dead");

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            enemyAudio.clip = deathClip;
            enemyAudio.Play();

            head.SetActive(false);
            hitParticles.Play();

            SetKinematic(false);
            GetComponent<Animator>().enabled = false;
            Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            int hitBodyIndex = Random.Range(0, bodies.Length - 1);
            for (var i = 0; i < bodies.Length; i++)
            {
                if (i == hitBodyIndex)
                {
                    bodies[i].AddForce(deathIntensity * hitDir);
                }

            }
            Destroy(gameObject, 2f);
        }

        void Death (Vector3 hitDir)
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Tell the animator that the enemy is dead.
            // anim.SetTrigger ("Dead");

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();

            SetKinematic(false);
            GetComponent<Animator>().enabled = false;
            Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            int hitBodyIndex = Random.Range(0, bodies.Length - 1);
            for (var i = 0; i < bodies.Length; i++)
            {
                if (i == hitBodyIndex)
                {
                    bodies[i].AddForce(deathIntensity * hitDir);
                }

            }
            Destroy(gameObject, 2f);
        }
        
       
        void SetKinematic(bool newValue)
        {
            Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in bodies)
            {
                rb.isKinematic = newValue;
            }
        }
    }
}