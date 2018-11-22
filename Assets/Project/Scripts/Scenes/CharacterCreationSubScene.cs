using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject
{
    public class CharacterCreationSubScene : SubScene
    {

        public GameObject player;
        public Transform playerPosition;

        public override void Enter()
        {
            gameObject.SetActive(true);
            player.transform.SetPositionAndRotation(playerPosition.position, playerPosition.rotation);
            player.GetComponentInChildren<PlayerShooting>().enabled = false;
            player.GetComponent<PlayerHealth>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<FieldOfView>().enabled = false;
        }

        public override void Exit()
        {
            gameObject.SetActive(false);
        }

    }
}
