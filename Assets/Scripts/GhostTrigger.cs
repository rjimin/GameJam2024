using UnityEngine;

public class GhostTriggered : MonoBehaviour
{
    public GameObject trappedGhost;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ghost"))
        {

            if (gameObject.CompareTag("Trap"))
            {

                if (trappedGhost != null)
                {
                    Instantiate(trappedGhost, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
