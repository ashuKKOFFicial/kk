// This code can be in a LapTrigger script attached to your lap completion area.
using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    public LapManager lapManager; // Reference to the LapManager script
    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int layer = 1 << other.gameObject.layer; // Get the layer of the entered object
        if ((lapManager.vehicleLayer.value & layer) > 0) // Check if the object is in the vehicle layer
        {

            
            // Handle lap completion
            // For example, increase lap count and then call the LapManager to display lap order
            LapCompleted();

            collider.enabled = false;

            Invoke(nameof(ColliderOn), 0f);
            
        }
    }

    public void ColliderOn()
    {

        collider.enabled = true;
    }

    private void LapCompleted()
    {
        // Handle lap completion, e.g., increase lap count, update lap time, etc.

        // Now call the LapManager to display the lap order
        lapManager.DisplayLapOrder();
    }
}
