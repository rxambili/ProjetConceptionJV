using UnityEngine;

namespace GameProject
{    public abstract class EnemySpawn : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.

        public abstract bool IsFinished();
    }
}