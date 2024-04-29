using UnityEngine;
using UnityEngine.EventSystems;

public class CamerasMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float movementSpeed = 1f;

    private bool isMoving = false;
    private Vector3 movementDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move the GameObject continuously while the button is pressed
            transform.Translate(movementDirection * Time.deltaTime * movementSpeed);
        }
    }

    // Called when the UI button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        // Set movement direction based on button press
        if (eventData.pointerPress.gameObject.name == "UpButton")
        {
            movementDirection = Vector3.up;
        }
        else if (eventData.pointerPress.gameObject.name == "DownButton")
        {
            movementDirection = Vector3.down;
        }
        else if (eventData.pointerPress.gameObject.name == "LeftButton")
        {
            movementDirection = Vector3.left;
        }
        else if (eventData.pointerPress.gameObject.name == "RightButton")
        {
            movementDirection = Vector3.right;
        }

        // Start moving
        isMoving = true;
    }

    // Called when the UI button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        // Stop moving when the button is released
        isMoving = false;
        movementDirection = Vector3.zero;
    }
}
