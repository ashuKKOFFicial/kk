using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class NitroOpacityController : MonoBehaviour
{
    public ParticleSystem[] nitroParticleSystems;
    private CarController carController;
    private float maxSpeed = 1000f;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        float normalizedSpeed = Mathf.Clamp01(carController.CurrentSpeed / maxSpeed);

        foreach (var nitroParticles in nitroParticleSystems)
        {
            if (nitroParticles != null)
            {
                var mainModule = nitroParticles.main;
                Color nitroColor = mainModule.startColor.color;
                nitroColor.a = normalizedSpeed;
                mainModule.startColor = nitroColor;
            }
        }
    }
}
