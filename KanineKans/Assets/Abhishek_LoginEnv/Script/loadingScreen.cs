    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScreen : MonoBehaviour
{
    public Slider loadingSlider;
    public Text loadingText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loadScreen()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CarAIWaypointBasedAashu");

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = progress;
            loadingText.text = (progress * 100).ToString("F0") + "%";
            print("=====" + progress);
            yield return null;
        }

    }

}
