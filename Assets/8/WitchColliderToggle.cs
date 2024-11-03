using UnityEngine;

public class WitchColliderToggle : MonoBehaviour
{
    public Collider2D playerCollider; 
    private Collider2D witchCollider; 

    void Start()
    {
        witchCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bridge"))
        {
            Physics2D.IgnoreCollision(witchCollider, playerCollider, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bridge"))
        {
            Physics2D.IgnoreCollision(witchCollider, playerCollider, false);
        }
    }
}
