using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneStage;
    private void OnMouseOver()
    {
        SceneManager.LoadScene(SceneStage);
    }
}




