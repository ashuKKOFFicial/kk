using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
public class CarParamController : MonoBehaviour
{


    public CarController carController;

    public Slider torqueSlider;
    public Slider topSpeedSlider;
    public Slider steeringSlider;
    public Slider downForceSlider;

    public Text torqueValueText;
    public Text topSpeedText;
    public Text steeringText;
    public Text downforceText;

    // Start is called before the first frame update
    void Start()
    {
        

        torqueSlider.minValue = 0;
        torqueSlider.maxValue = 10000;
        torqueSlider.value = carController.m_FullTorqueOverAllWheels;

        topSpeedSlider.minValue = 100;
        topSpeedSlider.maxValue = 400;
        topSpeedSlider.value = carController.m_Topspeed;

        steeringSlider.minValue = 2;
        steeringSlider.maxValue = 60;
        steeringSlider.value = carController.m_MaximumSteerAngle;

        downForceSlider.minValue = 100;
        downForceSlider.maxValue = 500;
        downForceSlider.value = carController.m_Downforce;
    }

    // Update is called once per frame
    void Update()
    {
        carController.m_FullTorqueOverAllWheels = (int)torqueSlider.value;
        torqueValueText.text = "Boost: " + torqueSlider.value;

        carController.m_Topspeed = (int)topSpeedSlider.value;
        topSpeedText.text = "Max Speed: " + topSpeedSlider.value;

        carController.m_MaximumSteerAngle = (int)steeringSlider.value;
        steeringText.text = "Handle: " + steeringSlider.value;

        carController.m_Downforce = (int)downForceSlider.value;
        downforceText.text = "Down Force: " + downForceSlider.value;


        
    }

   
    

}
