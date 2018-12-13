using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class EnemySpawnEndManager : MonoBehaviour {

        public BlockingObject[] blockingObjects;
        public RewardObject[] rewardObjects;
        public ParticleSystem particles;
        private GameObject enemyManager;
        EnemySpawn[] enemySpawns;
        private bool isActive;

        private void Awake()
        {
            enemySpawns = GetComponents<EnemySpawn>();
            enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
        }


        

        // Update is called once per frame
        void Update() {
            if (isActive && IsFinished())
            {                      
                foreach (BlockingObject obj in blockingObjects)
                {
                    obj.Unblock();
                }
                foreach (RewardObject obj in rewardObjects)
                {
                    obj.Reward();
                }
                if (particles != null)
                {
                    particles.Stop();
                }
                enabled = false;
                foreach (EnemyManager elm in enemyManager.GetComponents<EnemyManager>())
                {
                    elm.isPaused = false;
                }
                enemyManager.SetActive(true);
            }

        }

        public void Activate()
        {           
            if (!isActive)
            {               
                isActive = true;
                foreach (EnemyManager elm in enemyManager.GetComponents<EnemyManager>())
                {
                    elm.isPaused = true;
                }
                enemyManager.SetActive(false);
                foreach (BlockingObject obj in blockingObjects)
                {
                    obj.Block();
                }
                if (particles != null)
                {
                    particles.Play();
                }
            }
        }

        private bool IsFinished()
        {
            foreach (EnemySpawn e in enemySpawns)
            {
                if (!e.IsFinished())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
