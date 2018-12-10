using UnityEngine;

namespace GameProject
{
    public class EnemySlugHealth : EnemyHealth
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

        private void Start()
        {
            SetKinematic(true);
        }
        

        public override void TakeDamage (int amount, Vector3 hitPoint, Vector3 hitDir)
        {
            if (isShouting)
            {
                amount = (int)(amount * shoutingDamageMult);
            }
            base.TakeDamage(amount, hitPoint, hitDir);
        }

        

        public override void TakeDamage(int amount)
        {
            if (isShouting)
            {
                amount = (int)(amount * shoutingDamageMult);
            }
            base.TakeDamage(amount);            
        }
        
    }
}