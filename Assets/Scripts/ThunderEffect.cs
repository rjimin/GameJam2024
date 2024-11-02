using UnityEngine;
using System.Collections;

public class ThunderFlashEffect : MonoBehaviour
{
    private SpriteRenderer thunderSprite;
    public float flashDuration = 0.1f;
    public float delayBetweenFlashes = 1.5f;

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
