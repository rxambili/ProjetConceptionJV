using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace GameProject
{ 
    public class PlayerHealth : MonoBehaviour
    {
        private int startingHealth;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public int resistance;
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public AudioClip hurtClip;
        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


        Animator anim;                                              // Reference to the Animator component.
        public AudioSource playerAudio;                             // Reference to the AudioSource component.
        PlayerMovement playerMovement;                           // Reference to the PlayerShooting script.
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               // True when the player gets damaged.
        PlayerAttributesManager playerAttr;

        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerAttr = GetComponent<PlayerAttributesManager>();
        }

        private void Start()
        {
            // Set the initial health of the player.
            startingHealth = playerAttr.GetStartingHealth();
            currentHealth = startingHealth;
        }

        
        void Update ()
        {
            startingHealth = playerAttr.GetStartingHealth();
            resistance = playerAttr.GetResistance();
            // If the player has just been damaged...
            if (damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;
        }


        public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount * (1 - resistance/100);

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            if (playerAudio.isPlaying)
            {
                playerAudio.Stop();
            }
            playerAudio.clip = hurtClip;
            playerAudio.Play ();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death ();
            }
        }


        void Death ()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;
            PlayerShooting playerShooting = GetComponentInChildren<PlayerShooting>();
            // Turn off any remaining shooting effects.
            if (playerShooting != null)
            {
                playerShooting.DisableEffects();
                playerShooting.enabled = false;
            }

            // Tell the animator that the player is dead.
            anim.SetTrigger ("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play ();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
        }

        public int Heal(int amount)
        {
            int newHealth = Mathf.Min(startingHealth, currentHealth + amount);
            Debug.Log(startingHealth);
            int addedPv = newHealth - currentHealth;
            currentHealth = newHealth;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            return addedPv;
        }


        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene (0);
        }
    }
}