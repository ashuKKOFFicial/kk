using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public GameObject continueAsGuest;
    public GameObject connectToWallet;
    public AudioSource clickButton;
    public InputField userName;
    public InputField password;
    public Button continueButton;

    public void Start()
    {
        continueButton.interactable = false;

        userName.onValueChanged.AddListener(delegate { CheckInputFields(); });
        password.onValueChanged.AddListener(delegate { CheckInputFields(); });
    }

    public void ContinueAsGuest()
    {
        clickButton.Play();
        continueAsGuest.SetActive(true);
        connectToWallet.SetActive(false);
    }

    public void ConnectToWallet()
    {
        clickButton.Play();
        continueAsGuest.SetActive(false);
        connectToWallet.SetActive(true);

    }

    public void CheckInputFields()
    {
        continueButton.interactable = !string.IsNullOrEmpty(userName.text) &&
                                      !string.IsNullOrEmpty(password.text);
                                      

    }

   public void MM()
    {
        clickButton.Play();
        SceneManager.LoadScene("MAIN");
    }

    public void LoadPay3MoneyScene(string pay3loginScene)
    {
        clickButton.Play();
        SceneManager.LoadScene(pay3loginScene);

    }
}
