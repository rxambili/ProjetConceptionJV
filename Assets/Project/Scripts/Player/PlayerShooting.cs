using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace GameProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 0;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets = 1f;        // The time between each shot.
        public float range = 100f;                      // The distance the gun can fire.
        public int maxAmmo = 10;
        public int currentAmmo = 0;
        public bool isAuto;
        public AudioClip emptyGunClip;
        public AudioClip shootClip;
        public AudioClip reloadClip;


        float timer;                                    // A timer to determine when to fire.
        Ray shootRay = new Ray();                       // A ray from the gun end forwards.
        RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
        ParticleSystem gunParticles;                    // Reference to the particle system.
        LineRenderer gunLine;                           // Reference to the line renderer.
        AudioSource gunAudio;                           // Reference to the audio source.
        Light gunLight;                                 // Reference to the light component.
		public Light faceLight;								// Duh
        float effectsDisplayTime = 0.02f;                // The time that the effects will display for.
        PlayerAttributesManager playerAttr;
        Animator anim;
        Animator hudAnim;
        RessourcesManager playerRessources;
        bool isReloading = false;


        void Awake ()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask ("Shootable") | LayerMask.GetMask("Obstacle");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem> ();
            gunLine = GetComponent <LineRenderer> ();
            gunAudio = GetComponent<AudioSource> ();
            gunLight = GetComponent<Light> ();
            playerAttr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributesManager>();
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            hudAnim = GameObject.FindGameObjectWithTag("HUD").GetComponent<Animator>();
            playerRessources = GameObject.FindGameObjectWithTag("Player").GetComponent<RessourcesManager>();
            //faceLight = GetComponentInChildren<Light> ();
        }

        private void Start()
        {
            InitializeWithStats();
            currentAmmo = maxAmmo;
        }

        public void InitializeWithStats()
        {
            damagePerShot = playerAttr.GetAtkTir();
        }
        void Update ()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

#if !MOBILE_INPUT
            if (isAuto)
            {
                // If the Fire1 button is being press and it's time to fire...
                if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !isReloading)
                {
                    if (currentAmmo == 0)
                    {
                        gunAudio.clip = emptyGunClip;
                        gunAudio.Play();
                    }
                    else
                    {
                        // ... shoot the gun.
                        Shoot();
                    }
                }
            } else
            {
                // If the Fire1 button is being press and it's time to fire...
                if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !isReloading)
                {
                    if (currentAmmo == 0)
                    {
                        gunAudio.clip = emptyGunClip;
                        gunAudio.Play();
                    }
                    else
                    {
                        // ... shoot the gun.
                        Shoot();
                    }
                }
            }

            if (Input.GetButtonDown("Reload") && Time.timeScale != 0 && !isReloading)
            {
                // reload the gun.
                Reload();
            }
#else
            // If there is input on the shoot direction stick and it's time to fire...
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
#endif
            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects ();
            }
        }


        public void DisableEffects ()
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
			faceLight.enabled = false;
            gunLight.enabled = false;
        }


        void Shoot ()
        {
            // Reset the timer.
            timer = 0f;

            // Play the gun shot audioclip.
            gunAudio.Play ();

            // Enable the lights.
            gunLight.enabled = true;
			faceLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop ();
            gunParticles.Play ();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition (0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

                // If the EnemyHealth component exist...
                if(enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition (1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            }
            // animation
            anim.SetTrigger("Shoot");

            // réduire munitions
            currentAmmo--;
        }

        void Reload()
        {
            
            if (playerRessources.currentTotalAmmo > 0)
            {
                anim.SetTrigger("Reload");
                gunAudio.clip = reloadClip;
                gunAudio.volume = 0.1f*gunAudio.volume;
                gunAudio.Play();

            } else
            {
                anim.SetTrigger("FailedReload");
                hudAnim.SetTrigger("NoAmmo");
            }
            isReloading = true;
        }

        public void EndReload()
        {
            isReloading = false;
            currentAmmo = currentAmmo + playerRessources.UseAmmo(maxAmmo - currentAmmo);
            gunAudio.clip = shootClip;
            gunAudio.volume = 1f;
        }

        public void EndFailedReload()
        {
            isReloading = false;
        }

        public int GetAmmo()
        {
            return currentAmmo;
        }
    }
}