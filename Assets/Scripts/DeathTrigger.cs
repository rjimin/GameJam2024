using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public string deathSceneName = "DeathScreen"; // Name of the death screen scene
    public string ghostCollisionSceneName = "PlayerCollisionScene"; // Scene to load when the player collides with a ghost

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject.CompareTag("Ghost"))
        {
            // Load the specified scene when the player collides with a ghost
            SceneManager.LoadScene(ghostCollisionSceneName);
        }
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


