using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    private List<Transform> lapOrder; // List to store vehicles in lap order

    public LayerMask vehicleLayer; // The LayerMask for your vehicles

    private Collider collider;

    private void Start()
    {
        lapOrder = new List<Transform>();
        collider = GetComponent<Collider>();
    }

    // Called when a vehicle enters the lap trigger
    private void OnTriggerEnter(Collider other)
    {
        int layer = 1 << other.gameObject.layer; // Get the layer of the entered object
        if ((vehicleLayer.value & layer) > 0) // Check if the object is in the vehicle layer
        {
            Debug.Log("Vehicle entered lap trigger: " + other.name); // Add this line

            // Add the vehicle's transform to the list
            lapOrder.Add(other.transform);
            collider.enabled = false;

            Invoke(nameof(ColliderOn), 0f);
        }
    }

    // Sort and display the lap order
    public void DisplayLapOrder()
    {
        lapOrder.Sort((a, b) => a.position.z.CompareTo(b.position.z));

        for (int i = 0; i < lapOrder.Count; i++)
        {
            Debug.Log("Position " + (i + 1) + ": " + lapOrder[i].name);
        }
    }

    public void ColliderOn()
    {

        collider.enabled = true;
    }

}
