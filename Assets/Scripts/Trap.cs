using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject deathImagePrefab; // Assign death image prefab here

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trap is a target that should "die"
        if (other.CompareTag("Player") || other.CompareTag("Ghost")) // Adjust tags as needed
        {
            // "Kill" the object by disabling it
            other.gameObject.SetActive(false);

            // Instantiate the death image at the object's position
            Vector3 deathPosition = other.transform.position;
            Instantiate(deathImagePrefab, deathPosition, Quaternion.identity);

            // Optionally, you can destroy the object after a delay
            // Destroy(other.gameObject, 1f);
        }
    }
}
