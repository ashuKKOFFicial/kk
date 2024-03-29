using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonClicked : MonoBehaviour
{

    public void StartButton()
    {

        SceneManager.LoadScene("LoadingScene");
    }

   
}
