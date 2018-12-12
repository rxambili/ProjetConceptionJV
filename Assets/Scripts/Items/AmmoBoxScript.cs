using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
    public class AmmoBoxScript : MonoBehaviour {

        public int ammoAmount;
        private Text ammoAddText;
        private Animator hudAnim;

        RessourcesManager playerRessources;
        bool isInRange;
        // Use this for initialization
        void Awake() {
            playerRessources = GameObject.FindGameObjectWithTag("Player").GetComponent<RessourcesManager>();
            ammoAddText = GameObject.FindGameObjectWithTag("HUD").transform.Find("AmmoUI").Find("AmmoAddText").GetComponent<Text>();
            hudAnim = GameObject.FindGameObjectWithTag("HUD").GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Action") && isInRange)
            {
               int addedAmount = playerRessources.AddAmmo(ammoAmount);
               ammoAddText.text = string.Format("+{0} balles", addedAmount);
               hudAnim.SetTrigger("AddAmmo");
               Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                isInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                isInRange = false;
            }
        }
    }
}
