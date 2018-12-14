using UnityEngine;

namespace GameProject
{    public abstract class EnemySpawn : MonoBehaviour
    {
        protected PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.

        public abstract bool IsFinished();

        private void Awake()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
    }
}