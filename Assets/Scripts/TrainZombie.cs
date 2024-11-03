using UnityEngine;

public class DelayedMover : MonoBehaviour
{
    public float delay = 4.0f;           // Time to wait before making the object appear
    public float speed = 5.0f;           // Speed at which the object moves to the right

    private bool isMoving = false;       // Flag to start moving after delay

    void Start()
    {
        // Start with the object disabled
        gameObject.SetActive(false);
        // Activate the object after the specified delay
        Invoke("AppearAndMove", delay);
    }

    void AppearAndMove()
    {
        // Make the object appear
        gameObject.SetActive(true);
        // Start moving the object
        isMoving = true;
    }

    void Update()
    {
        // If the object is set to move, translate it to the right
        if (isMoving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Check if the object is out of the screen
            if (Camera.main.WorldToViewportPoint(transform.position).x > 1)
            {
                // Disable the object or destroy it if it’s out of bounds
                gameObject.SetActive(false);
                // Optionally, you could use Destroy(gameObject); if you don't need it anymore
            }
        }
    }
}
