using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterTrail : MonoBehaviour
{
    public float slideForce = 10f;
    public float trailDuration = 2f;


    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy or object
        if (other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply force for sliding
                rb.AddForce(transform.forward * slideForce, ForceMode.Impulse);
            }
        }
    }

    void Start()
    {
        // Destroy the ice trail after a certain duration
        Destroy(gameObject, trailDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
