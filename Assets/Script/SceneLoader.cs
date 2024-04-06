using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public InputField userName;
    public InputField password;
    public Button continueAsGuestBtn;

    // Start is called before the first frame update
    void Start()
    {
        continueAsGuestBtn.interactable = false;

        userName.onValueChanged.AddListener(CheckInputFields);
        password.onValueChanged.AddListener(CheckInputFields);
    }

    public void CheckInputFields(string _)
    {

        if(!string.IsNullOrEmpty(userName.text) && !string.IsNullOrEmpty(password.text))
        {

            continueAsGuestBtn.interactable = true;
        }


        else
        {
            continueAsGuestBtn.interactable = false;
        }
    }

    public void MM()
    {

        SceneManager.LoadScene("MAIN");
    }

    public void LoadPay3MoneyScene(string pay3loginScene)
    {
        SceneManager.LoadScene(pay3loginScene);

    }


}
