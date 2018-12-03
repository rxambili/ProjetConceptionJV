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
        public int criticalChance = 1;
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
            criticalChance = playerAttr.GetMeleeCriticalChance();
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
            EnemyHealth enemyHealth = GetClosestEnemy();
            if (enemyHealth != null)
            {
                int rnd = Random.Range(1, 100);
                if (rnd <= criticalChance)
                {
                    enemyHealth.TakeCriticalDamage(Vector3.zero);
                }
                else
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerHit);
                }
            }
        }

        EnemyHealth GetClosestEnemy()
        {
            EnemyHealth bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Collider[] enemies = Physics.OverlapSphere(transform.position, range, hitableMask);

            foreach (Collider potentialTarget in enemies)
            {
                Transform target = potentialTarget.transform;
                Vector2 targetPos2D = new Vector2(target.position.x, target.position.z);
                Vector2 transformPos2D = new Vector2(playerTransform.position.x, playerTransform.position.z);
                Vector2 directionToTarget = targetPos2D - transformPos2D;

                if (Vector2.Angle(new Vector2(playerTransform.forward.x, playerTransform.forward.z), directionToTarget.normalized) < hitAngle / 2)
                {
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    EnemyHealth potentialEnemy = potentialTarget.GetComponentInParent<EnemyHealth>();
                    if (potentialEnemy != null && dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialEnemy;
                    }
                }
            }

            return bestTarget;
        }


    }
}
