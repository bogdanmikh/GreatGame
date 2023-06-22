using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float lifeTime;
    
    public Rigidbody2D rb;
    public Transform Player;

    private Timer timer;

    bool isKill = false;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = new Timer();
        timer.initTimer(lifeTime);
        if (Player.position.x < transform.position.x) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void Update() {
        if (timer.playTimer()) {
            timer.updateTimer();
        } else {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!isKill && collision.gameObject.tag == "Enemy") {
            EnemyHealth healthE = collision.gameObject.GetComponent<EnemyHealth>();
            healthE.updateHealth();
        }
        rb.gravityScale = 2f;
    }
}
