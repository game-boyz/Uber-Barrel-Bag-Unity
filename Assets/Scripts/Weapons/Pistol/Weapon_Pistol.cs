using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pistol : Weapon {
    

    private void Awake() {
        type = (int)Weapon_Constants.Weapon_types.Pistol;
        animator = GetComponent<Animator>();
    }

    protected override void Fire() {
        
    }
}
