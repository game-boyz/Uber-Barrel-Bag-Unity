using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pistol : Weapon
{
    public Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    protected override void Fire() {
        animator.SetTrigger("Fire");
    }
}
