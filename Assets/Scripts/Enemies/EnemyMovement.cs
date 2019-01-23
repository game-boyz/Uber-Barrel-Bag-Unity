using UnityEngine;
using PhysicsObjects;
using System;

public class EnemyMovement : PhysicsObject
{
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DealDamage(int damage) {
        Debug.Log($"Ouch! You dealt {damage} damage to me!");
    }
}
