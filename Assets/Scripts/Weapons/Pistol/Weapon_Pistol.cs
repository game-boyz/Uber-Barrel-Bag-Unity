using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pistol : Weapon {
    public GameObject bullet;

    private void Awake() {
        type = (int)Weapon_Constants.Weapon_types.Pistol;
        animator = GetComponent<Animator>();
    }

    protected override void Fire() {
        GameObject bullet_position = transform.Find("Bullet_Position").gameObject;

        if (bullet_position != null) {
            GameObject new_bullet = Instantiate(bullet, bullet_position.transform.position, bullet_position.transform.rotation);
        }
    }
}
