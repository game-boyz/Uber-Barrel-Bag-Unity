using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pistol : Weapon
{
    public Animator animator;
    private int type = (int)Weapon_Constants.weapon_types.Pistol;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    protected override void Fire() {
        animator.SetTrigger("Fire");
    }
}
