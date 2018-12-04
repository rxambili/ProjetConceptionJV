using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
    public class AmmoBoxScript : MonoBehaviour {

        public int ammoAmount;
        public Text playerText;
        public Animator hudAnim;

        RessourcesManager playerRessources;
        bool isInRange;
        // Use this for initialization
        void Awake() {
            playerRessources = GameObject.FindGameObjectWithTag("Player").GetComponent<RessourcesManager>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Action") && isInRange)
            {
               int addedAmount = playerRessources.AddAmmo(ammoAmount);
               playerText.text = string.Format("+{0} balles", addedAmount);
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
