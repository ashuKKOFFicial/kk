using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRover : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Flying();
    }

    public void Flying()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.useGravity = false;
            rb.AddForce(Vector3.up * 500f * Time.deltaTime);

        }
    }
}
