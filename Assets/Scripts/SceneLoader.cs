using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
     public void LoadNextScene(string sceneName)
    {
        // Load the scene with the name "ID"
        SceneManager.LoadScene(sceneName);
    }
    // public void LoadNextScene()
    // {
    //     // Get the current active scene index and increment it to load the next scene
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentSceneIndex + 1);
    // }
}
