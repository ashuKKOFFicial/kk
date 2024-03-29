using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private Collider collider;


    private void Start()
    {
        collider = GetComponent<Collider>();
    }


    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Triggered");

        if(other.gameObject.CompareTag("Player"))
        {
            SaveScript.lastLapM = SaveScript.lapTimeMin;
            SaveScript.lastLapS = SaveScript.lapTimeSec;
            SaveScript.lapNumber++;
            SaveScript.lapChange = true;

            collider.enabled = false;

            Invoke(nameof(ColliderOn), 1f);
            if (SaveScript.lapNumber == 2)
            {

                SaveScript.bestLapTimeM = SaveScript.lastLapM;
                SaveScript.bestLapTimeS = SaveScript.lastLapS;
            }

        }
    }

    public void ColliderOn()
    {

        collider.enabled = true;

    }

    

}
