using UnityEngine;
using System.Collections;

public class LaughingScarecrow : MonoBehaviour
{
    public float stretchAmount = 1.2f;  // Factor to stretch vertically
    public float duration = 0.3f;       // Duration of each stretch and resume cycle
    public float pauseDuration = 1.0f;  // Pause duration after three bounces
    private Vector3 originalScale;      // To store the original scale of the scarecrow
    private Vector3 originalPosition;   // To store the original position of the scarecrow

    void Start()
    {
        // Save the original scale and position of the scarecrow
        originalScale = transform.localScale;
        originalPosition = transform.position;

        // Start the bouncing effect after a random initial delay
        float randomDelay = Random.Range(0f, 2f); // Random delay between 0 and 2 seconds
        StartCoroutine(BounceAndPause(randomDelay));
    }

    IEnumerator BounceAndPause(float initialDelay)
    {
        // Wait for the random initial delay
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Bounce three times
            for (int i = 0; i < 3; i++)
            {
                // Stretch vertically from the bottom
                Vector3 stretchedScale = new Vector3(originalScale.x, originalScale.y * stretchAmount, originalScale.z);
                Vector3 offsetPosition = new Vector3(originalPosition.x, originalPosition.y + (stretchedScale.y - originalScale.y) / 2, originalPosition.z);

                yield return StartCoroutine(ScaleAndPositionOverTime(stretchedScale, offsetPosition, duration));

                // Resume to original scale and position
                yield return StartCoroutine(ScaleAndPositionOverTime(originalScale, originalPosition, duration));
            }

            // Pause briefly after three bounces
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    IEnumerator ScaleAndPositionOverTime(Vector3 targetScale, Vector3 targetPosition, float time)
    {
        Vector3 startScale = transform.localScale;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / time);
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        transform.position = targetPosition;
    }
}
