using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject {
    public class AnimatorEventManager : MonoBehaviour {

        PlayerShooting playerShooting;

        private void Awake()
        {
            playerShooting = GetComponentInChildren<PlayerShooting>();
        }

        public void EndWeaponReload()
        {
            playerShooting.EndReload();
        }

        public void EndWeaponFailedReload()
        {
            playerShooting.EndFailedReload();
        }
    }
}
