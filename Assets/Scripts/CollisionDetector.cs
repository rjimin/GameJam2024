using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDebugger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
    }
}
