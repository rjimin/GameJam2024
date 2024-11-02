using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetup : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Load the scene with the name "ID"
        SceneManager.LoadScene("ID");
    }
}
