using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {
    public static class Weapon_Constants {
        public enum Weapon_types { Pistol };
    }

    public class Weapon : MonoBehaviour {

        // A weapon class inheriting from this class must specify its type
        // Types can be retrieved from Weapon_Constant.Weapon_Types in the Weapons namespace
        public int type;

        void Update() {
            // Fires when f key or left click is pressed
            if (Input.GetButtonDown("Fire1")) {
                Fire();
            }
        }

        protected virtual void Fire() { }
    }
}

