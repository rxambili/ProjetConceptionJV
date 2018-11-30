using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class MeleeAttack : MonoBehaviour
    {

        public int damagePerHit;
        public float timeBetweenHits = 1f;        // The time between each shot.
        public float range = 2f;
        public int hitAngle = 90;
        public bool isAuto;

        float timer;
        int hitableMask;
        Animator anim;
        PlayerAttributesManager playerAttr;

        private void Awake()
        {
            playerAttr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributesManager>();
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

            hitableMask = LayerMask.GetMask("Shootable");
        }
        void Start()
        {
            InitializeWithStats();
        }

        public void InitializeWithStats()
        {
            damagePerHit = playerAttr.GetAtkMelee();
        }

        // Update is called once per frame
        void Update()
        {

            timer += Time.deltaTime;
            if (isAuto)
            {
                // If the Fire1 button is being press and it's time to fire...
                if (Input.GetButton("Fire1") && timer >= timeBetweenHits && Time.timeScale != 0)
                {
                    Slash();
                }
            }
            else
            {
                // If the Fire1 button is being press and it's time to fire...
                if (Input.GetButtonDown("Fire1") && timer >= timeBetweenHits && Time.timeScale != 0)
                {
                    Slash();
                }
            }
        }

        void Slash()
        {
            anim.SetTrigger("Shoot");
            
        }

        public void InflictDamages()
        {
            Collider[] targetsInRange = Physics.OverlapSphere(transform.position, range, hitableMask);
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


            for (int i = 0; i < targetsInRange.Length; i++)
            {

                Transform target = targetsInRange[i].transform;
                Vector2 targetPos = new Vector2(target.position.x, target.position.z);

                Vector2 transformPos = new Vector2(playerTransform.position.x, playerTransform.position.z);
                Vector2 dirToTarget = (targetPos - transformPos).normalized;
                if (Vector2.Angle(new Vector2(playerTransform.forward.x, playerTransform.forward.z), dirToTarget) < hitAngle / 2)
                {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = targetsInRange[i].GetComponentInParent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null)
                    {
                        // ... the enemy should take damage.
                        enemyHealth.TakeDamage(damagePerHit);
                    }
                }
            }
        }

        
    }
}
