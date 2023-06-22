using UnityEngine;

public class EnemyMove1 : MonoBehaviour {

    public int horisontalSpeed;

    public Rigidbody2D rb;

    public int direction = 0;

    private void Update() {
        rb.velocity = new Vector2(horisontalSpeed * Time.deltaTime * direction, rb.velocity.y);
    }
}
