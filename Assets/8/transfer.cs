using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DelayedSceneLoader : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    public float delay = 3f; // Delay in seconds

    private void Start()
    {
        // Start the coroutine to load the scene after a delay
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
