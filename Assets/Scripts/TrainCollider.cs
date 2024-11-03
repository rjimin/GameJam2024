using UnityEngine;

public class TimedColliderControl : MonoBehaviour
{
    private Collider2D objectCollider; // Reference for 2D Collider (use Collider for 3D)
    
    void Start()
    {
        // Get the collider component attached to the object
        objectCollider = GetComponent<Collider2D>();

        // Start with the collider enabled
        objectCollider.enabled = true;

        // Schedule the collider to disable after 2 seconds
        Invoke("DisableCollider", 2f);

        // Schedule the collider to enable again after 8 seconds
        Invoke("EnableCollider", 15f);
    }

    // Disables the collider
    void DisableCollider()
    {
        objectCollider.enabled = false;
    }

    // Enables the collider
    void EnableCollider()
    {
        objectCollider.enabled = true;
    }
}
