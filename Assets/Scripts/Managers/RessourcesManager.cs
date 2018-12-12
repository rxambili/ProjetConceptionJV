using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject {
    public class RessourcesManager : MonoBehaviour {

        public Text ammoText;
        public Text orbeText;

        public int startingTotalAmmo;
        private int bonusAmmo;

        public int currentTotalAmmo { get; set; }

        // Use this for initialization
        void Start() {
            currentTotalAmmo = startingTotalAmmo;
        }

        // Update is called once per frame
        void Update() {
            PlayerShooting playerShooting = GetComponentInChildren<PlayerShooting>();
            if (playerShooting != null)
            {
                ammoText.text = string.Format("{0} / {1}", playerShooting.GetAmmo(), currentTotalAmmo);
            } else
            {
                ammoText.text = "Illimité";
            }
            orbeText.text = string.Format("{0} ", GameManager.instance.nbOrbes);
        }

        public int UseAmmo(int ammo)
        {
            int usedAmmo = Mathf.Min(ammo, currentTotalAmmo);
            currentTotalAmmo -= usedAmmo;
            return usedAmmo;
        }

        public int AddAmmo(int amount)
        {
            int addedAmount = (int) (amount * Mathf.Max(0f, 1f + bonusAmmo / 100f));
            currentTotalAmmo += addedAmount;
            return addedAmount;
        }

        public void AddBonusAmmo(int amount)
        {
            bonusAmmo += amount;
        }

        public int AddOrbe(int amount)
        {
            GameManager.instance.nbOrbes += amount;
            return amount;
        }

    }
}