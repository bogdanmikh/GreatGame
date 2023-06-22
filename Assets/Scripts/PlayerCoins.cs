using UnityEngine;

public class PlayerCoins : MonoBehaviour {
    public void Awake() {
        PlayerPrefs.GetInt("Coins", 0);
    }
}