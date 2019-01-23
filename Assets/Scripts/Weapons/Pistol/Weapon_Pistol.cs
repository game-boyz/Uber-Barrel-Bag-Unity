using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pistol : Weapon {
    public float force = 100000f;

    public GameObject bullet;
    public SpriteRenderer spriteRenderer;

    private void Awake() {
        type = (int)Weapon_Constants.Weapon_types.Pistol;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Fire() {

        // Grab the bullet placeholder from the weapon transform
        GameObject bullet_position = transform.Find("Bullet_Position").gameObject;

        if (bullet_position != null) {
            // Create a new bullet at the placeholder's position
            GameObject new_bullet = Instantiate(bullet, bullet_position.transform.position, bullet_position.transform.rotation);

            // Setup bullet direction
            float force_direction = 1;

            bool spriteFlipped = spriteRenderer.transform.eulerAngles.y < 181 && spriteRenderer.transform.eulerAngles.y > 179;

            if (spriteFlipped) {
                force_direction = -1;
            }

            // Apply force to the bullet in the weapon's direction
            new_bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * force_direction, 0));
        }
    }
}
