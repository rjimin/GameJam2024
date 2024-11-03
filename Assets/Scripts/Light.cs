using UnityEngine;

public class DelayedLightAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float delay = 2.0f; // Delay in seconds

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Hide the GameObject initially
        gameObject.SetActive(false);

        // Invoke the appearance and animation start after the delay
        Invoke("StartLightAnimation", delay);
    }

    private void StartLightAnimation()
    {
        // Make the object visible
        gameObject.SetActive(true);

        // Enable and play the animation if the Animator is present
        if (animator != null)
        {
            animator.enabled = true;
            animator.Play("LightOnAnimation"); // Replace with your actual animation name
        }
    }
}
