using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCProgressTracker : MonoBehaviour
{
    public TextMeshProUGUI progress;
    public int count;
    private bool hasEntered;
    public string aiNames ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoints") && !hasEntered)
        {
            hasEntered = true;
            count++;
            progress.text = aiNames+": " + count;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoints"))
        {
            hasEntered = false;
        }
    }
}
