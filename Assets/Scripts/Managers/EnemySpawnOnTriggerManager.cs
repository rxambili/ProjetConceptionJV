using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class EnemySpawnOnTriggerManager : EnemySpawn
    {
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

        List<GameObject> spawnedEnemies;
        bool isActive = false;

        private void Start()
        {
            spawnedEnemies = new List<GameObject>();
        }

        
        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            foreach (Transform spawnPoint in spawnPoints)
            {
                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                GameObject instantiatedEnemy = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
                spawnedEnemies.Add(instantiatedEnemy);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !isActive)
            {
                Spawn();
                EnemySpawnEndManager spawnEnd = GetComponent<EnemySpawnEndManager>();
                if (spawnEnd != null)
                {
                    spawnEnd.Activate();
                }
                isActive = true;
            }
        }

        public override bool IsFinished()
        {
            return isActive && (spawnedEnemies.Count == 0 || spawnedEnemies.TrueForAll(enemy => enemy == null));
        }
    }
}