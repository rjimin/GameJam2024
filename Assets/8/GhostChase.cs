using UnityEngine;

public class GhostChase : MonoBehaviour
{
    public Transform target;  // Reference to the character (target) the ghost will chase
    public float speed = 2.0f;  // Speed at which the ghost moves

    void Update()
    {
        // Move the ghost towards the target's position
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized; // Direction towards the target
            transform.position += direction * speed * Time.deltaTime; // Move the ghost
        }
    }
}
