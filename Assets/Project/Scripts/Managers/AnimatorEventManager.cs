using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject {
    public class AnimatorEventManager : MonoBehaviour {

        public void EndWeaponReload()
        {
            GetComponentInChildren<PlayerShooting>().EndReload();
        }

        public void EndWeaponFailedReload()
        {
            GetComponentInChildren<PlayerShooting>().EndFailedReload();
        }
    }
}
