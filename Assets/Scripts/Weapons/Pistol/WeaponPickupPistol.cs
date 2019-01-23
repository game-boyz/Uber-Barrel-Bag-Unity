using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponPickupPistol : WeaponPickup {
    void Start() {
        type = (int)WeaponConstants.WeaponTypes.Pistol;
    }

    void Update() {}
}
