using UnityEngine;

public class HorizontalFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float speed = 5f;  // Speed at which the ghost follows the player

    void Update()
    {
        // Check if player reference is assigned
        if (player != null)
        {
            // Calculate the target position, only updating the X position
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

            // Move the ghost towards the target position smoothly
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
