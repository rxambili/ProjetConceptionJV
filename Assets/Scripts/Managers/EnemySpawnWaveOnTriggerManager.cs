using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class EnemySpawnWaveOnTriggerManager : EnemySpawn
    {
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public float spawnTime = 3f;
        public int nbWaves = 3;

        List<GameObject> spawnedEnemies;
        bool isActive = false;
        int currentNbWave = 0;

        private void Start()
        {
            spawnedEnemies = new List<GameObject>();
        }

        private void Update()
        {
            if (isActive && currentNbWave >= nbWaves)
            {
                CancelInvoke();
            }
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
            currentNbWave++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !isActive)
            {
                InvokeRepeating("Spawn", 0, spawnTime);
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
            return currentNbWave == nbWaves && isActive && (spawnedEnemies.Count == 0 || spawnedEnemies.TrueForAll(enemy => enemy == null));
        }
    }
}