using UnityEngine;

public class TreeBreakTrigger : MonoBehaviour
{
    public GameObject brokenTree;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the tree");

            // Set the exact offset
            Vector3 offset = new Vector3(-2.81f, -2.17f, 0); // X = -3.01, Y = 2.17, Z = 0 for 2D

            // Instantiate the broken tree with the exact position offset
            Instantiate(brokenTree, transform.position + offset, transform.rotation);

            Destroy(gameObject); // Destroy the original tree
        }
    }
}
