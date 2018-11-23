using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class ExplorationSubScene : SubScene
    {

        public GameObject player;
        public Transform playerPosition;

        public override void Enter()
        {
            gameObject.SetActive(true);
            player.transform.SetPositionAndRotation(playerPosition.position, playerPosition.rotation);
            PlayerShooting shootingScript = player.GetComponentInChildren<PlayerShooting>();
            shootingScript.enabled = true;
            shootingScript.InitializeWithStats();
            PlayerHealth healthScript = player.GetComponentInChildren<PlayerHealth>();
            healthScript.enabled = true;
            healthScript.InitializeWithStats();
            PlayerMovement movementScript = player.GetComponentInChildren<PlayerMovement>();
            movementScript.enabled = true;
            movementScript.InitializeWithStats();
            FieldOfView fovScript = player.GetComponentInChildren<FieldOfView>();
            fovScript.enabled = true;
            fovScript.InitializeWithStats();
        }

        public override void Exit()
        {
            gameObject.SetActive(false);
        }

    }
}
