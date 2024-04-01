using UnityEngine;
using UnityEngine.UI;

public class CarflyingAbilities : MonoBehaviour
{
    public float thrustForce = 100f;
    public float pitchSpeed = 2f;
    public float rollSpeed = 2f;
    public float yawSpeed = 2f;

    public Button pitchUpButton;
    public Button pitchDownButton;
    public Button rollLeftButton;
    public Button rollRightButton;
    public Button yawLeftButton;
    public Button yawRightButton;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Add onClick listeners to handle button presses
        pitchUpButton.onClick.AddListener(() => SetPitch(1f));
        pitchDownButton.onClick.AddListener(() => SetPitch(-1f));
        rollLeftButton.onClick.AddListener(() => SetRoll(-1f));
        rollRightButton.onClick.AddListener(() => SetRoll(1f));
        yawLeftButton.onClick.AddListener(() => SetYaw(-1f));
        yawRightButton.onClick.AddListener(() => SetYaw(1f));
    }

    private void SetPitch(float direction)
    {
        // Apply pitch force based on button press
        float pitch = direction * pitchSpeed;
        Vector3 forwardForce = transform.forward * thrustForce * pitch;
        rb.AddForce(forwardForce);
        Debug.Log("SetPitch");
    }

    private void SetRoll(float direction)
    {
        // Apply roll torque based on button press
        float roll = direction * rollSpeed;
        Vector3 sidewaysTorque = transform.right * roll;
        rb.AddTorque(sidewaysTorque);
        Debug.Log("SetRoll");
    }

    private void SetYaw(float direction)
    {
        // Apply yaw torque based on button press
        float yaw = direction * yawSpeed;
        Vector3 upTorque = transform.up * yaw;
        rb.AddTorque(upTorque);
        Debug.Log("SetYaaw");
    }
}
