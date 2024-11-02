using UnityEngine;

public class GhostMovement : MonoBehaviour 
{
    public float speed = 3f; // Horizontal movement speed
    public float bounceAmplitude = 0.1f; // Height of the bounce
    public float bounceFrequency = 5f; // Speed of the bounce
    private bool movingRight = false; // Start by moving right if initially looking left
    private float originalY; // Original Y position

    void Start()
    {
        originalY = transform.position.y; // Store the starting Y position
    }

    void Update()
    {
        // Horizontal movement
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        // Vertical bounce effect
        float newY = originalY + Mathf.Sin(Time.time * bounceFrequency) * bounceAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if the enemy has reached the screen's edge
        if (IsAtScreenEdge())
        {
            // Flip direction
            movingRight = !movingRight;
            FlipSprite();
        }
    }

    private bool IsAtScreenEdge()
    {
        // Get the screen boundaries in world space
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // Check if the enemy's position is beyond the screen edges
        if (movingRight && transform.position.x >= screenRight)
            return true;
        if (!movingRight && transform.position.x <= screenLeft)
            return true;

        return false;
    }

    private void FlipSprite()
    {
        // Flip the sprite by inverting the x-scale
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
