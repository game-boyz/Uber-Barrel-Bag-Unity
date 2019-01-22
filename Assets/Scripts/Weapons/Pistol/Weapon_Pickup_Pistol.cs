using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pickup_Pistol : Weapon_Pickup {
    void Start() {
        type = (int)Weapon_Constants.weapon_types.Pistol;
    }

    void Update() {}
}
