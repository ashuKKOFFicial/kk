using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class playFabManager : MonoBehaviour
{
   private string titleId = "2AAD6";

    // Event raised after the PlayFab login operation completes
    public delegate void OnLoginCompleted(bool success);
    public static event OnLoginCompleted LoginCompleted;

    private void Start()
    {
        // Call the function to initiate the login process
        LoginToPlayFab();
    }

    private void LoginToPlayFab()
    {
        // Generate a unique identifier for the device
        string deviceId = SystemInfo.deviceUniqueIdentifier;

        // Prepare the request to send the device identifier to PlayFab
        var request = new LoginWithCustomIDRequest
        {
            CustomId = deviceId,
            CreateAccount = true // Create a new account if one with the same ID doesn't exist
        };

        // Call the PlayFab API to log in or create an account
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginResult, OnLoginError);
    }

    private void OnLoginResult(LoginResult result)
    {
        Debug.Log("Login successful!");
        // Invoke the event to notify other scripts about the login completion
        LoginCompleted?.Invoke(true);
        SendAppOpenEvent();
    }

    private void OnLoginError(PlayFabError error)
    {
        Debug.LogError("PlayFab login error: " + error.ErrorMessage);
        // Invoke the event to notify other scripts about the login completion (with failure)
        LoginCompleted?.Invoke(false);
    }
    private void SendAppOpenEvent()
    {
         var request = new WriteClientPlayerEventRequest
        {
            EventName = "AppOpen", // Event name for app open
            Body = new Dictionary<string, object>
            {
                { "OpenTimestamp", GetUnixTimestamp() } // Include timestamp in event body
            }
        };

        // Call the PlayFab API to write the player event
        PlayFabClientAPI.WritePlayerEvent(request, OnEventSent, OnEventSendError);
    }

    private void OnEventSent(WriteEventResponse response)
    {
        Debug.Log("App open event sent successfully!");
    }

    private void OnEventSendError(PlayFabError error)
    {
        Debug.LogError("Error sending app open event to PlayFab: " + error.ErrorMessage);
    }

    // Function to get current Unix timestamp
    private int GetUnixTimestamp()
    {
        return (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    }
}
