using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /**
     * Create functions that will help you move between scenes. To do so, you can invoke the
     * GetActiveScene() static function in the SceneManager Class. Ensure the UnityEngine.SceneManagement 
     * namespace is included in the file
     */
    
    //use this start to take off the annoying mouse in the game
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadCurrentScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void LoadNextScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadPreviousScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex - 1);
    }

    public void quitApplication() {
        print("game will quit");
        Application.Quit();
    }
 
}
