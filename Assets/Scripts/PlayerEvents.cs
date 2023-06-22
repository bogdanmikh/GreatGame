using UnityEngine;

public class PlayerEvents : MonoBehaviour {

    private PlayerHealth playerHealth;
    private bool strikeZone = false;

    void Start () {
        playerHealth = GetComponent<PlayerHealth>();
    }


    private void Update() {
        if (playerHealth.lives <= 0 || transform.position.y <= -30f) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (!strikeZone && collision.gameObject.tag == "Enemy" && !playerHealth.timerOn) {
            playerHealth.lives--;
            playerHealth.timerOn = true;
        } 
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Coin") {
            int coins = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.GetInt("Coins", coins + 1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy" && !playerHealth.timerOn) {
            strikeZone = true;
        } else if (strikeZone) strikeZone = false;

        if (collision.gameObject.tag == "Door") {
            LevelController.instance.lastLevel();
        }
    }
}
