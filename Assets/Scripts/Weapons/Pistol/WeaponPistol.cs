using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponPistol : Weapon {
    public float force = 100000f;

    public GameObject bullet;
    public SpriteRenderer spriteRenderer;

    private void Awake() {
        type = (int)WeaponConstants.WeaponTypes.Pistol;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Fire() {

        // Grab the bullet placeholder from the weapon transform
        GameObject bulletPosition = transform.Find("Bullet_Position").gameObject;

        if (bulletPosition != null) {
            // Create a new bullet at the placeholder's position
            GameObject newBullet = Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);

            // Setup bullet direction
            float forceDirection = 1;

            bool spriteFlipped = spriteRenderer.transform.eulerAngles.y < 181 && spriteRenderer.transform.eulerAngles.y > 179;

            if (spriteFlipped) {
                forceDirection = -1;
            }

            // Apply force to the bullet in the weapon's direction
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * forceDirection, 0));
        }
    }
}
