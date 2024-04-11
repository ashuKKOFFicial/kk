using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoTechBulletShoot : MonoBehaviour
{
    private float shootSpeed = 200f;
    //private Rigidbody rb;

    private void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * shootSpeed * Time.deltaTime;
        StartCoroutine(BulletStayTime());*/

        transform.Translate(transform.TransformDirection(Vector3.forward) * shootSpeed * Time.deltaTime, Space.World);
        //StartCoroutine(BulletStayTime());
    }
    // Update is called once per frame
    /*void Update()
    {
        transform.Translate(transform.TransformDirection(Vector3.forward) * shootSpeed * Time.deltaTime, Space.World);
        StartCoroutine(BulletStayTime());
    }*/

    /*IEnumerator BulletStayTime()
    {

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);

    }*/
}
