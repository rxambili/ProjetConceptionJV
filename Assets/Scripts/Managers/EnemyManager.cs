using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public float minDistance;
        public float maxDistance;
        public Transform player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }
            
            // Find a random index between zero and one less than the number of spawn points.
            int angle = Random.Range (0, 360);
            float distance = Random.Range(minDistance, maxDistance);

            Vector3 pos = new Vector3(distance * Mathf.Cos(angle * Mathf.Deg2Rad), 0f, distance * Mathf.Sin(angle * Mathf.Deg2Rad));
            
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy, player.position + pos, Quaternion.identity);
        }
    }
}