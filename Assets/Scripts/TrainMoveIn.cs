using UnityEngine;
using System.Collections;

public class TubeAnimator : MonoBehaviour
{
    private float animationDuration = 1.0f;
    private Vector3 startPosition = new Vector3(-8.96f, 9.12f, 0f);
    private Vector3 endPosition = new Vector3(-8.96f, 0.05f, 0f);

    void Start()
    {
        transform.position = startPosition;
        StartCoroutine(AnimateTube());
    }

    private IEnumerator AnimateTube()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / animationDuration;
            transform.position = Vector3.Lerp(startPosition, endPosition, normalizedTime);
            yield return null;
        }
        
        transform.position = endPosition;
    }
}
