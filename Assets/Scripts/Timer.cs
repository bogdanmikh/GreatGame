using UnityEngine;

public class Timer : MonoBehaviour {

    private float time;

    private void Awake() {
        time = 0f;
    }

    public void initTimer (float t) {
        time = t;
    }

    public void updateTimer () {
        if (time > 0) {
            time -= Time.deltaTime;
        }
    }

    public bool playTimer() {
        if (time > 0) {
            return true;
        } else {
            return false;
        }
    }
}
