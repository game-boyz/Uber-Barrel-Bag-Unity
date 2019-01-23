using UnityEngine;
using PhysicsObjects;
using System;

public class EnemyController : PhysicsObject
{
    private SpriteRenderer spriteRenderer;
    public int health = 20;
    public float hitColorResetTime = 0.15f;
    public Color hitColor = Color.red;
    public Color originalColor = Color.white;

    private float timeTillColorReset = -1;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        // Reset enemy hit color after the timeout
        if (Time.time > timeTillColorReset && timeTillColorReset > 0) {
            spriteRenderer.color = originalColor;
            timeTillColorReset = -1;
        }
    }

    public void DealDamage(int damage) {
        // Damage the enemy
        health -= damage;

        // Change its color to the hit color and then set a timeout to reset it
        timeTillColorReset = Time.time + hitColorResetTime;
        spriteRenderer.color = hitColor;

        // When the enemy runs out of health, kill it
        if (health <= 0) {
            Destroy(gameObject, hitColorResetTime + 0.05f);
        }
    }
}
