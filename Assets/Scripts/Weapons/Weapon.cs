using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {
    public static class Weapon_Constants {

        // NOTE: The order of this enum matters until there is a better way to map GameObjects in Weapon_Placeholder
        public enum weapon_types { Pistol };
    }

    public class Weapon : MonoBehaviour {
        public int type;

        // Update is called once per frame
        void Update() {
            // Fires when f key or left click is pressed
            if (Input.GetButtonDown("Fire1")) {
                Fire();
            }
        }

        protected virtual void Fire() { }
    }
}

