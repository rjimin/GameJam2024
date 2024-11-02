using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBreakTrigger : MonoBehaviour
{
    public GameObject brokenBridge;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the bridge");

            // Instantiate the broken bridge with the same position, rotation, and scale
            // GameObject newBrokenBridge = Instantiate(brokenBridge, transform.position, transform.rotation);
            Instantiate(brokenBridge, transform.position, transform.rotation);

            // Set the scale of the broken bridge to match the original bridge's scale
            // brokenBridge.transform.localScale = transform.localScale;

            Destroy(gameObject); // Destroy the original bridge
        }
    }
}
