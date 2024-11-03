using UnityEngine;

public class RestrictedPlayerControl : MonoBehaviour 
{
    private Camera mainCamera;
    public Vector3 initialPosition = new Vector3(0, 0, 0); // Set the initial spawn position here
    private bool isFollowingMouse = false; // Control when to start following the mouse

    // Define the bounds for the restricted area
    public Vector2 minBounds = new Vector2(-8.8f, -5f); // Bottom-left corner of the restricted area
    public Vector2 maxBounds = new Vector2(8.9f, -3f);   // Top-right corner of the restricted area

    void Start()
    {
        mainCamera = Camera.main;

        // Set the player to the designated initial position
        transform.position = initialPosition;

        // Optionally, start following the mouse after a short delay
        Invoke("StartFollowingMouse", 0.8f); // Starts following mouse after 0.5 seconds
    }

    void Update()
    {
        if (isFollowingMouse)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Keep the character's Z position fixed (for 2D)

            // Clamp the mouse position within the specified bounds
            mousePosition.x = Mathf.Clamp(mousePosition.x, minBounds.x, maxBounds.x);
            mousePosition.y = Mathf.Clamp(mousePosition.y, minBounds.y, maxBounds.y);

            // Set the character's position to the clamped mouse position
            transform.position = mousePosition;
        }
    }

    void StartFollowingMouse()
    {
        isFollowingMouse = true; // Allow the player to start following the mouse
    }
}
