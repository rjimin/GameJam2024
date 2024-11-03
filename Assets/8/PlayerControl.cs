using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Camera mainCamera;
    public Vector3 initialPosition = new Vector3(0, 0, 0); // Set the initial spawn position here
    private bool isFollowingMouse = false; // Control when to start following the mouse

    void Start()
    {
        mainCamera = Camera.main;

        // Set the player to the designated initial position
        transform.position = initialPosition;

        // Optionally, start following the mouse after a short delay
        Invoke("StartFollowingMouse", 1.5f); // Starts following mouse after 0.5 seconds
    }

    void Update()
    {
        if (isFollowingMouse)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Keep the character's Z position fixed (for 2D)

            // Set the character's position to the mouse position
            transform.position = mousePosition;
        }
    }

    void StartFollowingMouse()
    {
        isFollowingMouse = true; // Allow the player to start following the mouse
    }
}
