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
    public GameObject guestUi;
    public GameObject connectToWalletUI;
    public AudioSource clickSound;

    public GameObject updateUI;
    // Start is called before the first frame update
    void Start()
    {
        continueAsGuestBtn.interactable = false;

        userName.onValueChanged.AddListener(CheckInputFields);
        password.onValueChanged.AddListener(CheckInputFields);
    }

    public void CheckInputFields(string _)
    {
        clickSound.Play();
        if(!string.IsNullOrEmpty(userName.text) && !string.IsNullOrEmpty(password.text))
        {

            continueAsGuestBtn.interactable = true;
        }


        else
        {
            continueAsGuestBtn.interactable = false;
        }
    }

    public void Switch_To_Guest()
    {
        clickSound.Play();
        connectToWalletUI.SetActive(false);
        guestUi.SetActive(true);

    }

    public void Switch_To_Wallets()
    {

        clickSound.Play();
        connectToWalletUI.SetActive(true);
        guestUi.SetActive(false);
    }

    public void MM()
    {
        clickSound.Play();
        SceneManager.LoadScene("MAIN");
    }

    public void LoadPay3MoneyScene(string pay3loginScene)
    {
        clickSound.Play();
        SceneManager.LoadScene(pay3loginScene);

    }

    public void CloseUpdates()
    {
        updateUI.SetActive(false);

    }


}
