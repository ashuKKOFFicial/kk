using UnityEngine;
using TMPro;

public class ProgressTracker : MonoBehaviour
{
    public TextMeshProUGUI progress;
    public int count;

    // Use this flag to prevent multiple triggers in a short time
    private bool canCount = true;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is enabled and we can count
        if (canCount && other.CompareTag("Waypoints"))
        {
            count++;
            progress.text = "F1_JaL: " + count;

            // Disable counting for a short duration
            canCount = false;
            Invoke(nameof(EnableCounting), 0.2f);
        }
    }

    void EnableCounting()
    {
        canCount = true;
    }
}
