using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float health;

    public void updateHealth() {
        health--;
        if (health <= 0) {
            Destroy(gameObject, 0.1f);
        } 
    }
}