using UnityEngine;

public class ActivateCursorAfterDelay : MonoBehaviour
{
    public GameObject cursor; // Reference to the cursor GameObject
    public float delay = 5f;  // Time in seconds to wait before activating the cursor

    private Renderer cursorRenderer; // Reference to the cursor's Renderer component

    void Start()
    {
        if (cursor != null)
        {
            // Get the Renderer component (works for SpriteRenderer, MeshRenderer, etc.)
            cursorRenderer = cursor.GetComponent<Renderer>();

            // Make the cursor initially invisible by disabling its renderer
            SetCursorVisibility(false);

            // Start the coroutine to enable the cursor after a delay
            StartCoroutine(EnableCursorAfterDelay());
        }
        else
        {
            Debug.LogWarning("Cursor GameObject is not assigned.");
        }
    }

    private System.Collections.IEnumerator EnableCursorAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        
        // Make the cursor visible
        SetCursorVisibility(true);
    }

    private void SetCursorVisibility(bool isVisible)
    {
        if (cursorRenderer != null)
        {
            // Enable or disable the renderer to make the cursor visible or invisible
            cursorRenderer.enabled = isVisible;
        }
    }
}
