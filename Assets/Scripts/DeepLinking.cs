using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLinking : MonoBehaviour
{
    void Start()
    {
        // Check if there is an absolute URL
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            // Handle the deep link here
            string deepLink = Application.absoluteURL;
            Debug.Log("Deep Link: " + deepLink);
        }
    }


}
