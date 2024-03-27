using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class BrakeButton : MonoBehaviour
{
    private CarController m_Car; // Reference to the CarController script.
    public Button brakeButton; // Reference to the brake button.

    private void Awake()
    {
        // Get the CarController component attached to the same GameObject.
        m_Car = GetComponent<CarController>();

        // Add click listeners to the brake button.
        if (brakeButton != null)
        {
            brakeButton.onClick.AddListener(OnBrakeButtonDown);
            brakeButton.onClick.AddListener(OnBrakeButtonUp);
        }
    }

    private void OnBrakeButtonDown()
    {
        // Set footbrake input to 1 when the button is pressed.
        m_Car.Move(0, 0, 1, 0);
    }

    private void OnBrakeButtonUp()
    {
        // Set footbrake input to 0 when the button is released.
        m_Car.Move(0, 0, 0, 0);
    }
}
