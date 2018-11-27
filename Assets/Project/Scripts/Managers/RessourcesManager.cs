using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
    public class RessourcesManager : MonoBehaviour {

        public Text ammoText;

        public int startingTotalAmmo;
        public int currentTotalAmmo { get; set; }

        // Use this for initialization
        void Start() {
            currentTotalAmmo = startingTotalAmmo;
        }

        // Update is called once per frame
        void Update() {
            ammoText.text = string.Format("{0} / {1}", GetComponentInChildren<PlayerShooting>().GetAmmo(), currentTotalAmmo);
    
        }

        public int UseAmmo(int ammo)
        {
            int usedAmmo = Mathf.Min(ammo, currentTotalAmmo);
            currentTotalAmmo -= usedAmmo;
            return usedAmmo;
        }

        public void AddAmmo(int amount)
        {
            currentTotalAmmo += amount;
        }

    }
}