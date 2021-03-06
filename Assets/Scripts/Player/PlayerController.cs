﻿using UnityEngine;
using PhysicsObjects;
using Weapons;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Animator animator;
    public SpriteRenderer weaponSprite;
    public GameObject weapon;

    private bool inputLock = false;

    private SpriteRenderer spriteRenderer;
    private Transform playerLocation;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerLocation = GetComponent<Transform>();
    }

    // Flip the character and child gameobjects
    void FlipCharacter() {
        spriteRenderer.transform.Rotate(0f, 180f, 0f);
    }

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;
        bool spriteFlipped = spriteRenderer.transform.eulerAngles.y < 181 && spriteRenderer.transform.eulerAngles.y > 179;

        move.x = Input.GetAxis("Horizontal");

        // Handle jump controls / physics
        if (Input.GetButtonDown("Jump") && grounded && !inputLock) {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        // Handle horizontal movement and sprite flipping
        if (move.x > 0.01f && !inputLock) {
            if (spriteFlipped) {
                FlipCharacter();
            }
        }
        else if (move.x < -0.01f && !inputLock) {
            if (!spriteFlipped) {
                FlipCharacter();
            }
        }

        targetVelocity = move * maxSpeed;

        // Handle updating animations
        // The transitions in the Player Animation Controller will listen for these values
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y / maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        // Trigger a weapon pickup on collsion with that type of object
        if (collider.gameObject.CompareTag("WeaponPickup")) {
            WeaponPickup weapon = collider.gameObject.GetComponent<WeaponPickup>();
            WeaponPlaceholder playerWeapon = playerLocation.Find("WeaponPlaceholder").gameObject.GetComponent<WeaponPlaceholder>();

            // Spawn the 'picked up' weapon in the player's hands
            bool pickedUp = playerWeapon.SpawnWeapon(weapon.type);

            // Destroy the pickup
            if (pickedUp) {
                Destroy(collider.gameObject);
            }
        }
    }
}
