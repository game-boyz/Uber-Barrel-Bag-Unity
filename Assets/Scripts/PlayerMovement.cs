using UnityEngine;
using PhysicsObjects;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Animator animator;

    private bool inputLock = false;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1")) { // Fires when f key or left click is pressed
            animator.SetTrigger("Firing");
            inputLock = true;
        } else {
            inputLock = false;
        }

        // Handle movement controls / physics
        if (Input.GetButtonDown("Jump") && grounded && !inputLock)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move.x > 0.01f && !inputLock)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (move.x < -0.01f && !inputLock)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        targetVelocity = move * maxSpeed;

        // Handle updating animations
        // The transitions in the Player Animation Controller will listen for these values
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y / maxSpeed);


    }
}
