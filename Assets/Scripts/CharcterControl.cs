using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the character's Z position fixed (for 2D)

        // Set the character's position to the mouse position
        transform.position = mousePosition;
    }
}