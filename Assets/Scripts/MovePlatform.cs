using UnityEngine;

public class MovePlatform : MonoBehaviour {
    public bool moveOfAxisX;
    public float speed;
    public GameObject point1;
    public GameObject point2;

    private bool moveFirstPoint;

    private void Start() {
        moveFirstPoint = true;
        if (!moveOfAxisX) {
            point1.transform.position = new Vector3(transform.position.x, point1.transform.position.y, point1.transform.position.z);
            point2.transform.position = new Vector3(transform.position.x, point2.transform.position.y, point2.transform.position.z);
        } else {
            point1.transform.position = new Vector3(point1.transform.position.x, transform.position.y, point1.transform.position.z);
            point2.transform.position = new Vector3(point2.transform.position.x, transform.position.y, point2.transform.position.z);
        }
    }
    private void Update() {
        if (Vector2.Distance(point1.transform.position, gameObject.transform.position) <= 0.4f) { 
            moveFirstPoint = false;
        } 
        if (Vector2.Distance(point2.transform.position, gameObject.transform.position) <= 0.4f) {
            moveFirstPoint = true;
        }

        if (moveFirstPoint) {
            moveUp();
        } else {
            moveDown();
        }
    }
    private void moveUp() {
        if (moveOfAxisX) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y);
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed);
        }
    }

    private void moveDown() {
        if (moveOfAxisX) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y);
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.transform.SetParent(transform);
        } 
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.transform.SetParent(null);
    }
}
