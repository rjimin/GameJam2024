using UnityEngine;
using UnityEngine.UI;

public class ActivateButtonAfterDelay : MonoBehaviour
{
    private Button targetButton; // Reference to the button to activate
    public float delay = 5f; // Time in seconds to wait before activating the button

    private Image buttonImage;
    private Text buttonText;

    void Start()
    {
        // Find the Button component in the children of this GameObject
        targetButton = GetComponentInChildren<Button>();

        if (targetButton != null)
        {
            // Get the button's Image component
            buttonImage = targetButton.GetComponent<Image>();

            // Get the button's Text component (assuming it has one)
            buttonText = targetButton.GetComponentInChildren<Text>();

            // Make the button initially invisible
            SetButtonVisibility(false);

            // Start the coroutine to enable the button after a delay
            StartCoroutine(EnableButtonAfterDelay());
        }
        else
        {
            Debug.LogWarning("No Button component found in children.");
        }
    }

    private System.Collections.IEnumerator EnableButtonAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        
        // Make the button visible and enable interaction
        SetButtonVisibility(true);
        targetButton.interactable = true;
    }

    private void SetButtonVisibility(bool isVisible)
    {
        float alpha = isVisible ? 1f : 0f;

        // Set the button image's alpha
        if (buttonImage != null)
        {
            Color imageColor = buttonImage.color;
            imageColor.a = alpha;
            buttonImage.color = imageColor;
        }

        // Set the button text's alpha
        if (buttonText != null)
        {
            Color textColor = buttonText.color;
            textColor.a = alpha;
            buttonText.color = textColor;
        }
    }
}
