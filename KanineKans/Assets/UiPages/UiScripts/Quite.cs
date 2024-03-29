using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Quite : MonoBehaviour
{
    //public static Quite quite;

    public AudioSource clickSound;
    public void ApplicationQuite()
    {
        clickSound.Play();
        Application.Quit();
    }

    public void SwitchToMM()
    {
        clickSound.Play();
        SceneManager.LoadScene("MAIN");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
