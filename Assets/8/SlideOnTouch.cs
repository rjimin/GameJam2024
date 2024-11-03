using UnityEngine;

public class SlideOnTouch : MonoBehaviour
{
    public float slideDistance = 1f; // Distance the NPC will slide
    public float slideSpeed = 5f; // Speed of the sliding movement
    private bool isSliding = false; // Check if NPC is currently sliding

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with the NPC and if it’s not already sliding
        if (other.CompareTag("Player") && !isSliding)
        {
            // Calculate the direction to slide away from the player
            Vector3 slideDirection = (transform.position - other.transform.position).normalized;
            // Start sliding in the specified direction
            StartCoroutine(Slide(slideDirection));
        }
    }

    private System.Collections.IEnumerator Slide(Vector3 direction)
    {
        isSliding = true;
        Vector3 targetPosition = transform.position + direction * slideDistance;

        // Slide towards the target position
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, slideSpeed * Time.deltaTime);
            yield return null;
        }

        isSliding = false;
    }
}
