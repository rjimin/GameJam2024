using UnityEngine;

public class GhostMovementEnding : MonoBehaviour 
{
    public Vector2 startPoint; 
    public Vector2 endPoint; 
    public float speed = 3f; 
    public float bounceAmplitude = 0.1f; 
    public float bounceFrequency = 5f; 

    private bool movingRight; 
    private float originalY; 

    void Start()
    {
        transform.position = startPoint;
        originalY = startPoint.y; 

        movingRight = startPoint.x < endPoint.x;
    }

    void Update()
    {
        float step = speed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.position = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);

        float newY = originalY + Mathf.Sin(Time.time * bounceFrequency) * bounceAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (HasReachedEndPoint())
        {
            speed = 0;
        }
    }

    private bool HasReachedEndPoint()
    {
        if (movingRight && transform.position.x >= endPoint.x)
            return true;
        if (!movingRight && transform.position.x <= endPoint.x)
            return true;

        return false;
    }
}
