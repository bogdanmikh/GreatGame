using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int lives;
    public bool timerOn;

    [SerializeField] private Text livesText;
    [SerializeField] private float time;
    private float timeLeft = 0f;

    private void Start() {
        lives = 5;
        timeLeft = time;
        timerOn = false;
    }

    void Update() {
        if (timerOn) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                UpdatePlayer();
            } else {
                timeLeft = time;
                timerOn = false;
            }
        } else if (GetComponent<SpriteRenderer>().color == Color.gray) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        livesText.text = lives.ToString();
    }

    private void UpdatePlayer() {
        if (timeLeft < 0)
            timeLeft = 0;
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}
