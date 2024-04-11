using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingPowerUps : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICar"))
        {
            Debug.Log("=======================================AI collided =================================================");
            Vector3 newSize = other.transform.localScale * 0.9f;
            other.transform.localScale = newSize;

        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("AICar"))
        {
            Vector3 newSize = collision.transform.localScale * 2f;
            collision.transform.localScale = newSize;
            Debug.Log("AI - Bullet collsion happen==========================================");

        }
    }*/

}
