using UnityEngine;

public class EnemyMove3 : MonoBehaviour {

    public int horisontalSpeed;
    public int verticalSpeed;
    public float positionOfPatrol;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform point;
    public Transform player;
    public float stoppingDistance;
    private Rigidbody2D rb;

    private float forceX, forceY;

    bool movingRight;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (transform.position.y <= -30) {
            Destroy(gameObject);
        }

        if (angry == false && Vector2.Distance(transform.position, point.position) < positionOfPatrol) {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance) {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance) {
            goBack = true;
            angry = false;
        }

        if (chill) {
            Chill();
        } else if (angry) {
            Angry();
        } else if (goBack) {
            GoBack();
        }
    }

    private void FixedUpdate() {
        if (forceY != 0) {
            rb.velocity = new Vector2(forceX, forceY);
        } else {
            rb.velocity = new Vector2(forceX, rb.velocity.y);
        }
        forceY = 0;
    }

    void Chill() {
        if (transform.position.x > point.position.x + positionOfPatrol) {
            movingRight = false;
        } else if (transform.position.x < point.position.x - positionOfPatrol) {
            movingRight = true;
        }
        if (movingRight) {
            forceX = horisontalSpeed * Time.fixedDeltaTime;
        } else {
            forceX = -horisontalSpeed * Time.fixedDeltaTime;
        }
    }

    void Angry() {
        int direction;
        if (transform.position.x > player.position.x) {
            direction = -1;
        } else {
            direction = 1;
        }

        if (player.position.y > transform.position.y && isGrounded() &&
            player.position.y - transform.position.y >= 4f) {
            forceY = verticalSpeed * Time.fixedDeltaTime;
        } 
        forceX = direction * horisontalSpeed * 1.5f * Time.fixedDeltaTime;
    }

    void GoBack() {
        int direction;
        if (transform.position.x > point.position.x) {
            direction = -1;
        } else {
            direction = 1;
        }

        if (point.position.y > transform.position.y && isGrounded() &&
            point.position.y - transform.position.y >= 2f) {
            forceX = direction * horisontalSpeed * Time.fixedDeltaTime;
            forceY = verticalSpeed * Time.fixedDeltaTime;
        } else {
            forceX = direction * horisontalSpeed * Time.fixedDeltaTime;
        }
    }

    bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }
}
