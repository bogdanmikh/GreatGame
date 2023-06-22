using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    public float speed;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            rb.velocity = new Vector2(0, speed * Time.deltaTime);
        }
    }
}
