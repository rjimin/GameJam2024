using UnityEngine;
using System.Collections;

public class ThunderFlashEffect : MonoBehaviour
{
    private SpriteRenderer thunderSprite; // Reference to the SpriteRenderer component
    public float flashDuration = 0.1f; // Duration of each flash
    public float delayBetweenFlashes = 1.5f; // Delay between each thunder sequence

    private void Start()
    {
        thunderSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ThunderFlashRoutine());
    }

    private IEnumerator ThunderFlashRoutine()
    {
        while (true)
        {
            thunderSprite.enabled = true;
            yield return new WaitForSeconds(flashDuration);

            thunderSprite.enabled = false;
            yield return new WaitForSeconds(flashDuration * 0.5f);

            thunderSprite.enabled = true;
            yield return new WaitForSeconds(flashDuration);

            thunderSprite.enabled = false;
            yield return new WaitForSeconds(delayBetweenFlashes);
        }
    }
}
