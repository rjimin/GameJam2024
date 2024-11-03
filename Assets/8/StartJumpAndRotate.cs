using UnityEngine;

public class StartJumpAndRotate : MonoBehaviour 
{
    public Vector2 startPosition = new Vector2(-8f, 4f); // Starting position on the left edge
    public Vector2 endPosition = new Vector2(0f, 0f); // Target position in the middle of the screen
    public float jumpHeight = 5f; // Height of the jump arc
    public float jumpDuration = 2f; // Duration of the jump
    public float rotationSpeed = 360f; // Total rotation angle over the jump

    private float jumpProgress = 0f; // Tracks progress along the curve (0 to 1)
    private bool isJumping = true; // Track if the character is in the middle of the jump

    void Start()
    {
        // Set the character's initial position to the starting point
        transform.position = startPosition;
    }

    void Update()
    {
        if (isJumping)
        {
            // Increment jump progress based on time and duration
            jumpProgress += Time.deltaTime / jumpDuration;

            // Ensure progress does not exceed 1
            jumpProgress = Mathf.Clamp01(jumpProgress);

            // Calculate the parabolic curve between start and end positions
            float horizontalPosition = Mathf.Lerp(startPosition.x, endPosition.x, jumpProgress);
            float verticalPosition = Mathf.Lerp(startPosition.y, endPosition.y, jumpProgress) + jumpHeight * Mathf.Sin(Mathf.PI * jumpProgress);

            // Update the character's position
            transform.position = new Vector2(horizontalPosition, verticalPosition);

            // Rotate the character over the course of the jump
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);

            // Stop the jump once progress reaches 1 (end of the jump)
            if (jumpProgress >= 1f)
            {
                isJumping = false;
                transform.position = endPosition; // Ensure the character is exactly at the end position
            }
        }
    }
}
