using UnityEngine;
using PhysicsObjects;
using System;

public class EnemyController : PhysicsObject
{
    private SpriteRenderer spriteRenderer;
    public int health = 20;
    public float hitColorResetTime = 0.15f;
    private float timeTillColorReset = -1;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Debug.Log($"{Time.time} < {timeTillColorReset}");
        if (Time.time > timeTillColorReset && timeTillColorReset > 0) {
            //Debug.Log("dajskldajkl");
            spriteRenderer.color = Color.white;
            timeTillColorReset = -1;
        }
    }

    public void DealDamage(int damage) {
        timeTillColorReset = Time.time + hitColorResetTime;
        Debug.Log($"{timeTillColorReset}");
        health -= damage;
        spriteRenderer.color = Color.red;

        if (health <= 0) {
            Destroy(gameObject, hitColorResetTime + 0.05f);
        }
    }
}
