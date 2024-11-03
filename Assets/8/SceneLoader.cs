using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextSceneAsync());
        }
    }

    private IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null; // Wait until the scene is fully loaded
        }
    }
}
