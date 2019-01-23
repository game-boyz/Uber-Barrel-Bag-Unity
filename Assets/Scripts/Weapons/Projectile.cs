using UnityEngine;

public class Projectile : MonoBehaviour {
    public int damage;
    public float timeToLive = -1;
    private float timeAlive;

    void Start() { }

    void Update() {
        // Track how long the projectile has been in the world
        timeAlive += Time.deltaTime;

        if (timeAlive > timeToLive && timeToLive >= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Deal damage if necessary
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyController>().DealDamage(damage);
        }

        // Destroy bullet
        Destroy(gameObject);
    }
}
