using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {
    public class Weapon : MonoBehaviour {

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

