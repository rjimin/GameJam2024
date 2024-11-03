using UnityEngine;
using System.Collections;

public class TextBounceEffect : MonoBehaviour
{
    public float stretchAmount = 1.2f;  // How much to stretch the text vertically
    public float duration = 0.3f;       // Duration of each bounce cycle
    public int bounceCount = 3;         // Number of bounces before a pause
    public float pauseDuration = 1.0f;  // Pause duration after bounces

    private Vector3 originalScale;      // To store the original scale of the text

    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(BounceAndPause());
    }

    private IEnumerator BounceAndPause()
    {
        while (true)
        {
            // Perform the bounce effect for the specified number of times
            for (int i = 0; i < bounceCount; i++)
            {
                // Stretch vertically
                Vector3 stretchedScale = new Vector3(originalScale.x, originalScale.y * stretchAmount, originalScale.z);
                yield return StartCoroutine(ScaleOverTime(stretchedScale, duration));

                // Resume to original scale
                yield return StartCoroutine(ScaleOverTime(originalScale, duration));
            }

            // Pause briefly after the bounces
            yield return new WaitForSeconds(pauseDuration);
        }
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float time)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
