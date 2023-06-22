using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour {

    public int horisontalSpeed;

    public Rigidbody2D rb;
    public Transform point;

    public Transform player;
    public PlayerMove playerMove;

    private EnemyHealth health;

    private bool isGo = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = gameObject.GetComponent<EnemyHealth>();
    }

    private void FixedUpdate() {
        if (isGo) {
            rb.velocity = new Vector2(-horisontalSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

    private void Update() {
        if (player.position.x > point.position.x) {
            isGo = true;
        }
    }
}
