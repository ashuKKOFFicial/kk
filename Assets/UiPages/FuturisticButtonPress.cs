using UnityEngine;
using UnityEngine.UI;

public class FuturisticButtonPress : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isPressed = false;

    void Start()
    {
        // Store the original scale of the button
        originalScale = transform.localScale;

        // Add button click event listener
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Set the button to pressed state
        isPressed = true;

        // Tween the button scale down when pressed
        LeanTween.scale(gameObject, originalScale * 2.9f, 0.1f)
            .setEase(LeanTweenType.easeOutQuad);
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && isPressed)
            {
                // Reset the button scale when touch ends
                LeanTween.scale(gameObject, originalScale, 0.1f)
                    .setEase(LeanTweenType.easeOutQuad);

                isPressed = false;
            }
        }
    }
}
