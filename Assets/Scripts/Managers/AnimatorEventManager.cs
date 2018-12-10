using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject {
    public class AnimatorEventManager : MonoBehaviour {

        public void InflictMeleeDamages()
        {
            GetComponentInChildren<MeleeAttack>().InflictDamages();
        }
    }
}
