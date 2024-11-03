using UnityEngine;

public class LandmineByDistance : MonoBehaviour
{
    public Transform player;  
    public GameObject targetObject;
    public float activationDistance = 5f;

    private Renderer targetRenderer;

    void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();

        if (targetRenderer != null)
        {
            targetRenderer.enabled = false;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= activationDistance && targetRenderer != null && !targetRenderer.enabled)
        {
            targetRenderer.enabled = true;
        }
        else if (distance > activationDistance && targetRenderer != null && targetRenderer.enabled)
        {
            targetRenderer.enabled = false;
        }
    }
}
