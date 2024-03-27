using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveScript : MonoBehaviour
{
    
    public static float speed;
    public static float topSpeed;
    public static bool BrakeSlide;

    public static int gear;
    public static int lapNumber;
    public static bool lapChange = false;

    public static float lapTimeMin;
    public static float lapTimeSec;

    public static float raceTimeMin;
    public static float raceTimeSec;

    public static float bestLapTimeM;
    public static float bestLapTimeS;
    public static float lastLapM;
    public static float lastLapS;

    public TextMeshProUGUI points;
    public TextMeshProUGUI tokensText;
    public int playerPoints = 0;
    private int tokens = 0;

    public GameObject continueUI;
    public bool continuePanal;

    // Start is called before the first frame update
    void Start()
    {
        points.text = "Player's Points: " + playerPoints;
        tokensText.text = "KK COINS: " + tokens;
    }

    // Update is called once per frame
    void Update()
    {
        if (lapChange == true)
        {
            lapChange = false;
            lapTimeMin = 0f;
            lapTimeSec = 0f;

            // Increase player points by 5 on lap completion
            playerPoints += 5;
            points.text = "Player Points: " + playerPoints;

            // Check for tokens every 100 points
            if (playerPoints % 5 == 0)
            {
                // Award 1 kk token
                tokens++;
                tokensText.text = "KK COINS: " + tokens;
            }
        }


        if (lapNumber >= 1)
        {
            lapTimeSec = lapTimeSec + 1 * Time.deltaTime;
            raceTimeSec = raceTimeSec + 1 * Time.deltaTime;
            //Debug.Log("Lap time Sec: " + lapTimeSec);

        }

        if (lapTimeSec > 59)
        {
            lapTimeSec = 0f;
            lapTimeMin++;
        }

        if (raceTimeSec > 59)
        {
            raceTimeSec = 0f;
            raceTimeMin++;
        }

        if (lapNumber >= 2)
        {
            // Pause the game and show the pause menu.
            Time.timeScale = 0f;
            continueUI.SetActive(true);
            continuePanal = true;
            lapNumber = 0;
        }
    }

    public void ContinueGame()
    {
        
        
        SceneManager.LoadScene("CarAIWaypointBasedAashu");
        

    }

    public void CrossUI()
    {
        if (continuePanal == true)
        {
            continueUI.SetActive(false);
            continuePanal = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("CarAIWaypointBasedAashu");
        }
        
        

    }
}
