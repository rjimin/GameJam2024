// using UnityEngine;

// public class GhostTriggered : MonoBehaviour
// {
//     public GameObject trappedGhost;

//     private void OnTriggerEnter2D(Collider2D other)
//     {

//         if (other.CompareTag("Ghost"))
//         {

//             if (gameObject.CompareTag("Trap"))
//             {

//                 if (trappedGhost != null)
//                 {
//                     Collider2D trapCollider = GetComponent<Collider2D>();

//                     // Calculate the center of the trap's collider
//                     Vector2 trapCenter = trapCollider.bounds.center;
//                     Instantiate(trappedGhost, trapCenter, other.transform.rotation);
//                     Destroy(other.gameObject);
//                 }
//             }
//         }
//     }
// }
using UnityEngine;
using System.Collections.Generic;

public class GhostTriggered : MonoBehaviour
{
    public GameObject trappedGhost;
    private BoxCollider2D[] trapColliders;
    private Dictionary<bool, List<Vector2>> spawnPoints = new Dictionary<bool, List<Vector2>>(); // bool: isLeft
    private Dictionary<bool, int> ghostCount = new Dictionary<bool, int>(); // Track ghosts per trap

    private void Start()
    {
        trapColliders = GetComponents<BoxCollider2D>();
        spawnPoints[true] = new List<Vector2>();  // Left trap points
        spawnPoints[false] = new List<Vector2>(); // Right trap points
        ghostCount[true] = 0;  // Left trap count
        ghostCount[false] = 0; // Right trap count

        foreach (BoxCollider2D collider in trapColliders)
        {
            bool isLeft = collider.bounds.center.x < 0;
            float trapWidth = collider.bounds.size.x;
            float sectionWidth = trapWidth / 4;
            float startX = collider.bounds.min.x + (sectionWidth / 2); // Start at first section center
            float y = collider.bounds.min.y + (collider.bounds.size.y/3);

            // Create 4 spawn points for this trap
            for (int i = 0; i < 4; i++)
            {
                Vector2 spawnPoint = new Vector2(startX + (sectionWidth * i), y);
                spawnPoints[isLeft].Add(spawnPoint);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost") && gameObject.CompareTag("Trap"))
        {
            bool isLeft = other.transform.position.x < 0;

            // Check if trap is full
            if (ghostCount[isLeft] >= 4)
            {
                Debug.Log($"{(isLeft ? "Left" : "Right")} trap is full!");
                return;
            }

            if (trappedGhost != null)
            {
                // Get next available spawn position
                Vector2 spawnPosition = spawnPoints[isLeft][ghostCount[isLeft]];
                
                // Spawn ghost and increment counter
                Instantiate(trappedGhost, spawnPosition, other.transform.rotation);
                ghostCount[isLeft]++;
                
                Destroy(other.gameObject);
            }
        }
    }
}