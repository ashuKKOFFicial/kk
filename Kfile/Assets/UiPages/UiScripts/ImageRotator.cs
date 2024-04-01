using UnityEngine;

public class ImageRotator : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the image around the Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
