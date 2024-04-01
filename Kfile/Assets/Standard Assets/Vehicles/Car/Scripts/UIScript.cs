using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public Image speedRing;
    private float displaySpeed;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI gearText;
    public TextMeshProUGUI lapNumberText;
    public TextMeshProUGUI totalLapsText;

    public TextMeshProUGUI lapTimeMinText;
    public TextMeshProUGUI lapTimeSecText;

    public TextMeshProUGUI raceTimeMinText;
    public TextMeshProUGUI raceTimeSecText;

    public TextMeshProUGUI bestLapTimeMin;
    public TextMeshProUGUI bestLapTimeMinNew;
    public TextMeshProUGUI bestLapTimeSec;
    public TextMeshProUGUI bestLapTimeSecNew;

    public int totalLaps = 3;
    public AudioSource clickSound;


    // Start is called before the first frame update
    public void Start()
    {
        speedRing.fillAmount = 0;
        speedText.text = "0";
        gearText.text = "1";
        lapNumberText.text = "0";
        totalLapsText.text = "/"+totalLaps.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Speedometer
        Debug.Log("savescript.topspeed: " + SaveScript.topSpeed);
        displaySpeed = SaveScript.speed / SaveScript.topSpeed;
        Debug.Log("Display Speed: " + displaySpeed);

        speedRing.fillAmount = displaySpeed;
        speedText.text = (Mathf.Round(SaveScript.speed).ToString());
        gearText.text = (SaveScript.gear+1).ToString();
        
        //Lap Number
        lapNumberText.text = SaveScript.lapNumber.ToString();

        //Lap Time
        if (SaveScript.lapTimeMin <= 9)
        {
            lapTimeMinText.text = "0" + (Mathf.Round(SaveScript.lapTimeMin).ToString()) + ":";
        }

        else if (SaveScript.lapTimeMin >= 10)
        {
            lapTimeMinText.text = (Mathf.Round(SaveScript.lapTimeMin).ToString()) + ":";
        }

        if (SaveScript.lapTimeSec <= 9)
        {
            lapTimeSecText.text = "0" + (Mathf.Round(SaveScript.lapTimeSec).ToString());
        }

        else if (SaveScript.lapTimeSec >= 10)
        {
            lapTimeSecText.text = (Mathf.Round(SaveScript.lapTimeSec).ToString());
        }

        //Race Time
         if (SaveScript.raceTimeMin <= 9)
        {
            raceTimeMinText.text = "0" + (Mathf.Round(SaveScript.raceTimeMin).ToString()) + ":";
        }

        else if (SaveScript.raceTimeMin >= 10)
        {
            raceTimeMinText.text = (Mathf.Round(SaveScript.raceTimeMin).ToString()) + ":";
        }

        if (SaveScript.raceTimeSec <= 9)
        {
            raceTimeSecText.text = "0" + (Mathf.Round(SaveScript.raceTimeSec).ToString());
        }

        else if (SaveScript.raceTimeSec >= 10)
        {
            raceTimeSecText.text = (Mathf.Round(SaveScript.raceTimeSec).ToString());
        }

        //Besl Lap Time
        if (SaveScript.lastLapM == SaveScript.bestLapTimeM)
        {

            if (SaveScript.lastLapS < SaveScript.bestLapTimeS)
            {

                SaveScript.bestLapTimeS = SaveScript.lastLapS;

            }

        }

        if (SaveScript.lastLapM < SaveScript.bestLapTimeM)
        {
            SaveScript.bestLapTimeM = SaveScript.lastLapM;
            SaveScript.bestLapTimeS = SaveScript.lastLapS;
        }

        //Display Best Time Lap
        if (SaveScript.bestLapTimeM <= 9)
        {
            bestLapTimeMin.text = "0" + (Mathf.Round(SaveScript.bestLapTimeM).ToString()) + ":";
            bestLapTimeMinNew.text = "0" + (Mathf.Round(SaveScript.bestLapTimeM).ToString()) + ":";
        }

        else if (SaveScript.bestLapTimeM >= 10)
        {
            bestLapTimeMin.text = (Mathf.Round(SaveScript.bestLapTimeM).ToString()) + ":";
            bestLapTimeMinNew.text = (Mathf.Round(SaveScript.bestLapTimeM).ToString()) + ":";
        }

        if (SaveScript.bestLapTimeS <= 9)
        {
            bestLapTimeSec.text = "0" + (Mathf.Round(SaveScript.bestLapTimeS).ToString());
            bestLapTimeSecNew.text = "0" + (Mathf.Round(SaveScript.bestLapTimeS).ToString());
        }

        else if (SaveScript.bestLapTimeS >= 10)
        {
            bestLapTimeSec.text = (Mathf.Round(SaveScript.bestLapTimeS).ToString());
            bestLapTimeSecNew.text = (Mathf.Round(SaveScript.bestLapTimeS).ToString());
        }

    }

    public void ResetGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("CarAIWaypointBasedAashu");
        SaveScript.lapNumber = 0;
    }


}
