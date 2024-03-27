using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using Unity.Collections;
using System.Collections;
using UnityEngine.SceneManagement;

public class CallingAPiTrikon : MonoBehaviour
{
    private string signInApiUrl = "https://gamedev.trikon.io/vault/signInSocial";
    private string checkAuthStatusApiUrl = "https://gamedev.trikon.io/vault/checkAuthStatusSocial";
    private string mintGameTokensApiUrl = "https://gamedev.trikon.io/vault/mintGameTokens";

    private string chain = "0x13881";
    private string tokenKey = "SignInToken";

    public Button signInButton;
    public Button checkAuthStatusButton;
    public Text nameText;
    public Image profileImage;

    UnityWebRequest signInRequest;
    UnityWebRequest checkAuthStatusRequest;

    public Button connectButton;
    public string token;
    public GameObject connectToWallets;
    public GameObject continueButton;
    public GameObject userInfo;
    public GameObject walletsGameobj;

    public Text apiResponse;

    //public string urlToLoad = "http://gamedev.trikonecosystem.io/game/login?token"; // Replace with your desired URL
    void Start()
    {
       

        // Attach methods to be called when the buttons are clicked
        signInButton.onClick.AddListener(OnSignInButtonClick);
        // Attach the method to be called when the button is clicked
        //connectButton.onClick.AddListener(OpenTrikonURL);
        checkAuthStatusButton.onClick.AddListener(OnCheckAuthStatusButtonClick);

        string storedtoken = PlayerPrefs.GetString(tokenKey);

        /*if (!string.IsNullOrEmpty(storedtoken))
        {
            SceneManager.LoadScene("LoadingScene");
        }*/

    }

    void OnSignInButtonClick()
    {
        StartCoroutine(SendSignInSocialRequest());
    }

    public void OnCheckAuthStatusButtonClick()
    {
        // Retrieve the stored token
        string storedToken = PlayerPrefs.GetString(tokenKey);

        if (!string.IsNullOrEmpty(storedToken))
        {
            StartCoroutine(CheckAuthStatus(storedToken));
            //SceneManager.LoadScene("CarAIWaypointBasedAashu");
            
        }
        else
        {
            Debug.LogWarning("Token not found. Please sign in first.");
        }
    }

    public IEnumerator SendSignInSocialRequest()
    {
        // Create a JSON object with the request body data using SimpleJSON
        JSONNode signInRequestBody = new JSONObject();
        signInRequestBody["chain"] = chain;

        // Create a UnityWebRequest POST object for sign-in
        signInRequest = UnityWebRequest.PostWwwForm(signInApiUrl, "POST");

        // Set the request headers
        signInRequest.SetRequestHeader("Content-Type", "application/json");

        // Convert the JSON object to a byte array and set it as the request body
        byte[] signInBodyRaw = System.Text.Encoding.UTF8.GetBytes(signInRequestBody.ToString());
        signInRequest.uploadHandler = new UploadHandlerRaw(signInBodyRaw);
        signInRequest.downloadHandler = new DownloadHandlerBuffer();

        // Send the sign-in request
        yield return signInRequest.SendWebRequest();

        // Check for errors in sign-in
        if (signInRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Sign-in Error: " + signInRequest.error);

            apiResponse.text = "Sign-in Error: " + signInRequest.error;
        }
        else
        {
            // Successfully received a response for sign-in
            Debug.Log("Sign-in Response: " + signInRequest.downloadHandler.text);
            //apiResponse.text = "Sign-in Response: " + signInRequest.downloadHandler.text;
            // Parse the JSON response
            JSONNode signInJsonResponse = JSON.Parse(signInRequest.downloadHandler.text);

            // Check if the response contains a token
            if (signInJsonResponse["data"] != null && signInJsonResponse["data"]["token"] != null)
            {
                // Store the token in PlayerPrefs
                token = signInJsonResponse["data"]["token"];
                PlayerPrefs.SetString(tokenKey, token);
                PlayerPrefs.Save();

                Debug.Log("Token stored: " + token);


                // Call the second API to check authentication status
                //StartCoroutine(CheckAuthStatus(token));
                walletsGameobj.SetActive(false);
                OpenTrikonURL();
                connectToWallets.SetActive(false);
                continueButton.SetActive(true);
                //StartCoroutine(CheckAuthStatus(token));
                //OnCheckAuthStatusButtonClick();
            }
            else
            {
                Debug.LogWarning("Token not found in the sign-in response.");
            }
        }
    }

    public IEnumerator CheckAuthStatus(string token)
    {
        // Create a JSON object with the request body data for check authentication status
        JSONNode checkAuthStatusRequestBody = new JSONObject();
        checkAuthStatusRequestBody["token"] = token;

        // Create a UnityWebRequest POST object for check authentication status
        checkAuthStatusRequest = UnityWebRequest.PostWwwForm(checkAuthStatusApiUrl, "POST");

        // Set the request headers
        checkAuthStatusRequest.SetRequestHeader("Content-Type", "application/json");

        // Convert the JSON object to a byte array and set it as the request body
        byte[] checkAuthStatusBodyRaw = System.Text.Encoding.UTF8.GetBytes(checkAuthStatusRequestBody.ToString());
        checkAuthStatusRequest.uploadHandler = new UploadHandlerRaw(checkAuthStatusBodyRaw);
        checkAuthStatusRequest.downloadHandler = new DownloadHandlerBuffer();

        // Send the check authentication status request
        yield return checkAuthStatusRequest.SendWebRequest();

        // Check for errors in check authentication status
        if (checkAuthStatusRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Check Auth Status Error: " + checkAuthStatusRequest.error);
        }
        else
        {
            // Successfully received a response for check authentication status
            Debug.Log("Check Auth Status Response: " + checkAuthStatusRequest.downloadHandler.text);

            // You can handle the check authentication status response here
            // Extract data from authStatusObj
            JSONNode checkAuthStatusJsonResponse = JSON.Parse(checkAuthStatusRequest.downloadHandler.text);

            if (checkAuthStatusJsonResponse["data"] != null && checkAuthStatusJsonResponse["data"]["authStatusObj"] != null)
            {
                // Extract data from authStatusObj
                JSONNode authStatusObj = checkAuthStatusJsonResponse["data"]["authStatusObj"];

                // Display name
                if (authStatusObj["name"] != null)
                {
                    nameText.text = authStatusObj["name"];
                }

                // Display profile image
                if (authStatusObj["profileImage"] != null)
                {
                    StartCoroutine(LoadImage(authStatusObj["profileImage"]));
                }
                continueButton.SetActive(false);
                userInfo.SetActive(true);
            }
        }
    }

    /*public IEnumerator MintGameToken()
    {
        //create a JSON object with the request body data for check authentication Status
        JSONNode mintgametokenRequestBody = new JSONObject();






        yield return;


    }*/

    public IEnumerator LoadImage(string imageUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            // Get the texture from the downloaded data
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Apply the loaded texture to the profile image
            profileImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            Debug.LogError("Error loading image: " + www.error);
        }
    }

    public void OpenTrikonURL()
    {
        // Redirect to the specified URL
        //Utils.LaunchUrl("http://gamedev.trikonecosystem.io/game/login?token=" + token);
        Application.OpenURL("http://gamedev.trikonecosystem.io/game/login?token=" + token);
    }

    public void OnClickContinueButton()
    {

        continueButton.SetActive(false);
        userInfo.SetActive(true);
    }
}
