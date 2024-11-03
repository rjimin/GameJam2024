using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelaySwitch : MonoBehaviour
{
    public string SceneStage;

    private void Start()
    {
        LoadNextSceneWithDelay();
    }

    public void LoadNextSceneWithDelay()
    {
        StartCoroutine(DelaySceneSwitch(3f));
    }

    private IEnumerator DelaySceneSwitch(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneStage);
    }
}
