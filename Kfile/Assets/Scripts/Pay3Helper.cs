namespace Pay3.SDK.Helper {
  using Firebase.Extensions;
  using Firebase.Auth;
  using Firebase.Database;
  using Firebase;
  using System;
  using System.Text;
  using System.Collections;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using UnityEngine;
  using TMPro;
    using UnityEngine.SceneManagement; 


  // Handler for UI buttons on the scene.  Also performs some
  // necessary setup (initializing the firebase app, etc) on
  // startup.
  public class Pay3Helper : MonoBehaviour {
    protected bool isFirebaseInitialized = false;

    protected FirebaseApp fbApp;

    protected Firebase.Auth.FirebaseAuth auth;

    protected string fbUserId;
    public Pay3SDKConfig  sdkConfig;
    public Pay3Session sessionInfo;

    public TextMeshProUGUI loginInfoText;
    
    public TextMeshProUGUI loginBtnText;

    protected Dictionary<string, Firebase.Auth.FirebaseUser> userByAuth =
      new Dictionary<string, Firebase.Auth.FirebaseUser>();

    private Firebase.AppOptions authOptions; 

    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;

        public GameObject exploreButton;

    // When the app starts, check to make sure that we have
    // the required dependencies to use Firebase, and if not,
    // add them if possible.
    public virtual void Start() {
      LoadConfig();
      Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
        dependencyStatus = task.Result;
        if (dependencyStatus == Firebase.DependencyStatus.Available && !isFirebaseInitialized) {
          InitializeFirebaseAuth();
          isFirebaseInitialized = true;
        } else {
          Debug.LogError(
            "Could not resolve all Firebase dependencies: " + dependencyStatus);
        }
      });
            //kk
            exploreButton.SetActive(false);
    }

    protected void LoadConfig() {
       authOptions = new Firebase.AppOptions {
        ApiKey = sdkConfig.appNotifyApiKey,
        AppId = sdkConfig.appNotifyAppId,
        ProjectId = sdkConfig.appNotifyProjectId,
        DatabaseUrl = new Uri(sdkConfig.appNotifyDatabaseUrl),
        StorageBucket = sdkConfig.appNotifyStorageBucket
      };
    }

    // Handle initialization of the necessary firebase modules:
    private void InitializeFirebaseAuth() {
      Debug.Log("Auth: Setting up");
      if (authOptions != null &&
          !(String.IsNullOrEmpty(authOptions.ApiKey) ||
            String.IsNullOrEmpty(authOptions.AppId) ||
            String.IsNullOrEmpty(authOptions.ProjectId))) {
        fbApp = Firebase.FirebaseApp.Create(authOptions, "Pay3");      
        try {
          Debug.Log("Auth Anonymous Signin " + fbApp.ToString());
          auth = Firebase.Auth.FirebaseAuth.GetAuth(fbApp);
          SignInAnonymously();
          auth.StateChanged += AuthStateChanged;
        } catch (Exception) {
          Debug.Log("Auth: ERROR: Failed to initialize authentication object.");
        }
      } else {
        Debug.LogError("ERROR: App Notification config not set");
      }
      AuthStateChanged(this, null);
    }

    private void SignInAnonymously() {
      // Request anonymous sign-in and wait until asynchronous call completes.
      auth.SignInAnonymouslyAsync().ContinueWith((authTask) => {
      // Print sign in results.
        if (authTask.IsCanceled) {
          Debug.Log("Auth Sign-in canceled.");
        } else if (authTask.IsFaulted) {
          Debug.Log("Auth Sign-in encountered an error.");
          Debug.Log(authTask.Exception.ToString());
        } else if (authTask.IsCompleted) {
          Firebase.Auth.FirebaseUser user = authTask.Result.User;
          Debug.Log(String.Format("Auth: Signed in as {0} user.",
              user.IsAnonymous ? "an anonymous" : "a non-anonymous"));
          fbUserId = user.UserId;
          Debug.Log("Auth User Id " + user.UserId);
        }
      });
    }

        // Track state changes of the auth object.
    private void AuthStateChanged(object sender, System.EventArgs eventArgs) {
      Debug.Log("Auth State Changed " + eventArgs.ToString());
      Firebase.Auth.FirebaseAuth senderAuth = sender as Firebase.Auth.FirebaseAuth;
      Firebase.Auth.FirebaseUser user = null;
      if (senderAuth != null) userByAuth.TryGetValue(senderAuth.App.Name, out user);
      if (senderAuth == auth && senderAuth.CurrentUser != user) {
        bool signedIn = user != senderAuth.CurrentUser && senderAuth.CurrentUser != null;
        if (!signedIn && user != null) {
          Debug.Log("Auth Signed out UserId: " + user.UserId);
        }
        user = senderAuth.CurrentUser;
        userByAuth[senderAuth.App.Name] = user;
        if (signedIn && user.UserId != null) {
          Debug.Log("Fb loggedin UserId: " + user.UserId);
          StartLoginListener(user.UserId);
        }
      }
    }

    private void StartLoginListener(string userId) {
      FirebaseDatabase.GetInstance(fbApp)
        .GetReference("/app_notifications/"+userId+"/pay3-sdk-login-status")
        .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
          if (e2.DatabaseError != null) {
            Debug.LogError("DB: ERROR " + e2.DatabaseError.Message);
            return;
          }
          Debug.Log("DB: Received values from app_notification");
          long ts = 0;
          if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0) {
            Debug.Log("DB: Found data ");
            foreach (var childSnapshot in e2.Snapshot.Children) {
              Debug.Log("DB: Snapshot key " + childSnapshot.Key.ToString() + " Value: " + childSnapshot.Value.ToString());
              if (childSnapshot.Key.ToString() == "ts") {
                ts = (long) childSnapshot.Value;
              } else if (childSnapshot.Key.ToString() == "data" && childSnapshot.ChildrenCount > 0) {
                foreach (var grandChildSnapshot in childSnapshot.Children) {
                  if (grandChildSnapshot.Key.ToString() == "isLoggedIn") {
                    sessionInfo.isLoggedIn = (bool) grandChildSnapshot.Value;
                  } else if (grandChildSnapshot.Key.ToString() == "pay3Session") {
                    foreach (var sessionObj in grandChildSnapshot.Children) {
                      if (sessionObj.Key.ToString() == "walletAddress") {
                        sessionInfo.address = sessionObj.Value.ToString();
                      } else if (sessionObj.Key.ToString() == "jwtToken") {
                        sessionInfo.jwtToken = sessionObj.Value.ToString();
                      }
                    }
                  }
                }
              }
            }
            ShowLoginInfo();
          } else {
            Debug.Log("DB: Empty data found");
          }
        };
    }

    public void TriggerOpenLogin()
    {
        if(fbUserId != null && !sessionInfo.isLoggedIn) {
          string loginPayload = "{\"appNotify\":{\"uid\":\"" + fbUserId + "\"}," + "\"requestId\":\"" + Guid.NewGuid().ToString() + "\"}";
          string clientId = sdkConfig.pay3ClientId;
          string deepLink = sdkConfig.appDeepLink;
          string hostName = sdkConfig.pay3HostName;
          byte[] plainTextBytes = Encoding.UTF8.GetBytes(loginPayload);
          string requestParam = Convert.ToBase64String(plainTextBytes);
          string reqUrl = "https://"+hostName+"/web-sdk/"+ clientId +"?referrer="+deepLink+"&action=login&data=" + requestParam;
          Application.OpenURL(reqUrl);
        } else {
          resetSession();
          ShowLoginInfo();
          Debug.Log("Logout");
        }
    }

    private void ShowLoginInfo() {
      if(sessionInfo.isLoggedIn) {
        loginInfoText.GetComponent<TextMeshProUGUI>().text = "User Logged In. WalletAddress:" + sessionInfo.address  + " jwt:" + sessionInfo.jwtToken;
        loginBtnText.GetComponent<TextMeshProUGUI>().text = "Logout";

                //KK
                exploreButton.SetActive(true);
      } else {
        loginInfoText.GetComponent<TextMeshProUGUI>().text = "User Not Logged In";
        loginBtnText.GetComponent<TextMeshProUGUI>().text = "Login";


                //kk
                exploreButton.SetActive(false);
      }
    }

    private void resetSession() {
      sessionInfo.isLoggedIn = false;
      sessionInfo.address = "";
      sessionInfo.jwtToken = "";
    }

        public void ExploreButtonClick()
        {
            SceneManager.LoadScene("LoadingScene");
            

        }
  }
}
