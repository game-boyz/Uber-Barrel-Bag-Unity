using UnityEngine;
using PhysicsObjects;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public Animator animator;
    public SpriteRenderer weapon;

    private bool inputLock = false;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Flip the character and child gameobjects
    void FlipCharacter() {
        spriteRenderer.transform.Rotate(0f, 180f, 0f);
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        bool spriteFlipped = spriteRenderer.transform.eulerAngles.y < 181 && spriteRenderer.transform.eulerAngles.y > 179;

        move.x = Input.GetAxis("Horizontal");

        // Fires when f key or left click is pressed
        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("Firing");
            inputLock = true;
        } else {
            inputLock = false;
        }

        // Handle jump controls / physics
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

        // Handle horizontal movement and sprite flipping
        if (move.x > 0.01f && !inputLock)
        {
            if (spriteFlipped)
            {
                FlipCharacter();
            }
        }
        else if (move.x < -0.01f && !inputLock)
        {
            if (!spriteFlipped)
            {
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
}
