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
            player.GetComponentInChildren<PlayerShooting>().enabled = true;
            player.GetComponent<PlayerHealth>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponentInChildren<FieldOfView>().enabled = true;
        }

        public override void Exit()
        {
            gameObject.SetActive(false);
        }

    }
}
