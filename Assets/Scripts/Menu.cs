using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    public List<Button> level;
    private int quantity_levels;
    private int levelComplete;

    void Start() {
        quantity_levels = level.Count;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        
        for (int i = 0; i < quantity_levels; i++) {
            if (levelComplete <= i) {

            }
        }
    }

    public void LoadTo(int level) {
        SceneManager.LoadScene(level);
    }

    public void Reset() {
        PlayerPrefs.DeleteAll();
    }
}