using UnityEngine;

public class EnemyStrikeZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerMove playerMove = collision.gameObject.GetComponent<PlayerMove>();
            playerMove.jumpKill();
            EnemyHealth enemyHealth = gameObject.GetComponent<EnemyHealth>();
            enemyHealth.updateHealth();
        }
    }
}
