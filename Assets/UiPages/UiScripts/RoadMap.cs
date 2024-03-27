using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoadMap : MonoBehaviour
{

    //private SoundManager soundManager;
    public AudioSource buttonClickAudio;
    private void Awake()
    {
        //soundManager = SoundManager.instance;
    }

    public void BackClick()
    {

        buttonClickAudio.Play();
        //soundManager.PlayButtonClickSound();
        SceneManager.LoadScene("MAIN");
    }
}
