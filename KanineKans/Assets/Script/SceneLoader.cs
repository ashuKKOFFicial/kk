using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

   public void MM()
    {

        SceneManager.LoadScene("MAIN");
    }

    public void LoadPay3MoneyScene(string pay3loginScene)
    {
        SceneManager.LoadScene(pay3loginScene);

    }
}
