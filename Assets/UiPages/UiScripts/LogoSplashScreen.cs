using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogoSplashScreen : MonoBehaviour
{

    IEnumerator LogoSplash()
    {

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LoginScene");
        

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
