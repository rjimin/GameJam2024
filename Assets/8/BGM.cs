using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    private void Awake()
    {
        // Singleton pattern to keep only one instance of this GameObject
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }
}
