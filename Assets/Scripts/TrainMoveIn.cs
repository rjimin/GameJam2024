using UnityEngine;
using System.Collections;

public class TubeAnimator : MonoBehaviour
{
    private float animationDuration = 1.0f;
    private Vector3 startPosition = new Vector3(-8.93f, 10.13f, 0f);
    private Vector3 endPosition = new Vector3(-8.93f, -0.01f, 0f);

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
