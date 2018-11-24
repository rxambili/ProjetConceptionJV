using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.
        
        Animator anim;                          // Reference to the animator component.
        private bool isOver;


        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }

        private void Start()
        {
            isOver = false;
        }


        void Update ()
        {
            // If the player has run out of health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
                isOver = true;
            }

            if (Input.GetButton("Fire1") && isOver)
            {
                PlayerStats.Reset();
                SceneManager.LoadScene(0);
            }
        }
    }
}