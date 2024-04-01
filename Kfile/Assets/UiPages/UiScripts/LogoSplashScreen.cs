using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSplashScreen : MonoBehaviour
{

    IEnumerator LogoSplash()
    {

        yield return new WaitForSeconds(5f);
        UIManager.instance.logo.SetActive(false);
        UIManager.instance.mainMenu.SetActive(true);


    }

    private void Awake()
    {
        StartCoroutine(LogoSplash());
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
