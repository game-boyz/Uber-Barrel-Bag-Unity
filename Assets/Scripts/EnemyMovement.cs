using UnityEngine;
using PhysicsObjects;

public class EnemyMovement : PhysicsObject
{
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
