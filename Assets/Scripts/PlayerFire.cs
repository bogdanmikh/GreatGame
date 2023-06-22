using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject bullet;
    public Transform shotPoint;

    private float recharge;
    private Timer timer;

    void Start() {
        recharge = 0.5f;
        timer = new Timer();
        timer.initTimer(0);
    }

    void Update() {
        if (timer.playTimer()) {
            timer.updateTimer();
        } 
    }   

    public void OnButtonFire () {
        if (!timer.playTimer()) {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            timer.initTimer(recharge);
        } 
    }
}
