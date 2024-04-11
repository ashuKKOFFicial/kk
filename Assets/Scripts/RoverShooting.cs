using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverShooting : MonoBehaviour
{
    public GameObject fireTrailPrafab;
    public Transform spawnPoint;


    public void NanoTechShoot()
    {
        GameObject nano = Instantiate(fireTrailPrafab, spawnPoint.position, Quaternion.identity);
    }
}
