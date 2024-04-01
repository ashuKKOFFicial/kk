using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DroneScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float waypointRadius = 1.0f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        if (waypoints.Length > 0)
        {

            MoveToWaypoint(0);
        }
        else
        {
            Debug.LogWarning("No waypoints assigned to the drone.");
        }
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= waypointRadius)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            MoveToWaypoint(currentWaypointIndex);
        }
    }

    private void MoveToWaypoint(int waypointIndex)
    {
        Vector3 direction = waypoints[waypointIndex].position - transform.position;
        direction.Normalize();

        transform.forward = direction;


        GetComponent<Rigidbody>().velocity = direction * moveSpeed;
    }
}
