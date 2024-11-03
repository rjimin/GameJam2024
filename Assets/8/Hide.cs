using UnityEngine;

public class HidingSpot : MonoBehaviour 
{
    private bool isPlayerHidden = false;
    private SpriteRenderer playerSpriteRenderer;
    private Collider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerSpriteRenderer = other.GetComponent<SpriteRenderer>();
            playerCollider = other.GetComponent<Collider2D>();

            if (playerSpriteRenderer != null && playerCollider != null)
            {
                playerSpriteRenderer.enabled = false;
                playerCollider.enabled = false;
                isPlayerHidden = true;
            }
        }
    }

    private void Update()
    {
        if (isPlayerHidden)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D treeCollider = GetComponent<Collider2D>();

            // If mouse is outside the tree's collider
            if (!treeCollider.OverlapPoint(mousePosition))
            {
                UnhidePlayer();
            }
        }
    }

    private void UnhidePlayer()
    {
        if (playerSpriteRenderer != null && playerCollider != null)
        {
            playerSpriteRenderer.enabled = true;
            playerCollider.enabled = true;
            isPlayerHidden = false;
        }
    }
}