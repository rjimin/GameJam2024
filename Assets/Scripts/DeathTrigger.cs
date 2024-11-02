using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public string deathSceneName = "DeathScreen"; // Name of the death screen scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(deathSceneName);
        }
        else if (other.CompareTag("Ghost"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
