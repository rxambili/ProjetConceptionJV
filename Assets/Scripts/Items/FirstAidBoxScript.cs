using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
    public class FirstAidBoxScript : MonoBehaviour {

        public int pvAmount;
        // public Text pvAddText;
        // public Animator hudAnim;

        PlayerHealth playerHealth;
        bool isInRange;
        // Use this for initialization
        void Awake() {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Action") && isInRange)
            {
               int addedAmount = playerHealth.Heal(pvAmount);
               //pvAddText.text = string.Format("+{0} balles", addedAmount);
               //hudAnim.SetTrigger("Heal");
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
