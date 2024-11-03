using UnityEngine;

public class GhostMoveSecret : MonoBehaviour
{
    public float speed = 5f;
    private bool hasBounced = false;

    private Vector2 screenBounds;

    void Start()
    {
        // Calculate screen bounds in world units based on the camera
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        // Move the ghost to the left
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Check if the ghost reaches the screen's left edge and hasn't bounced yet
        if (!hasBounced && transform.position.x <= -screenBounds.x)
        {
            // Bounce back to the right
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            speed = -speed;
            hasBounced = true;
        }

        // Check if the ghost reaches the screen's right edge
        else if (transform.position.x >= screenBounds.x)
        {
            // Destroy the ghost when it reaches the right edge after bouncing
            Destroy(gameObject);
        }
    }
}
