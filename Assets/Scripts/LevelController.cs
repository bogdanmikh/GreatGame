using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;

    void Start() {

        if (instance == null) {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void lastLevel() {
        if (sceneIndex == 1) {
            Invoke("LoadMenu", 0.1f);
        } else {
            if (levelComplete < sceneIndex) {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            Invoke("NextLevel", 0.1f);
        }
    }

    void NextLevel() {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
}