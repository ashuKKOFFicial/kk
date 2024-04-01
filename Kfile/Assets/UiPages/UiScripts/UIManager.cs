using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mainMenu;
    public GameObject Story;
    public GameObject leaderBoard;
    
    public GameObject levelScene;
    public GameObject roverSelection;
    
    public GameObject logo;
    public GameObject settings;
    private SoundManager soundManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        soundManager = SoundManager.instance;
    }
    

    public void ShowMainMenu()
    {

        ShowScenes(mainMenu);
        soundManager.PlayButtonClickSound();
    }

    public void ShowStory()
    {
        ShowScenes(Story);
    }

    public void ShowLeaderBoard()
    {
        ShowScenes(leaderBoard);
    }

    public void ShowLoadingScene()
    {
        //ShowScenes(loadingScene);
        //loadingScene.SetActive(true);
        //mainMenu.SetActive(false);
        soundManager.PlayButtonClickSound();
        SceneManager.LoadScene("LoadingScene");
    }
    public void ShowLevelScene()
    {
        soundManager.PlayButtonClickSound();
        ShowScenes(levelScene);
        
    }

    public void ShowRoverSelection()
    {
        soundManager.PlayButtonClickSound();
        ShowScenes(roverSelection);
        
    
    }
    
    public void Logo()
    {

        ShowScenes(logo);
    
    
    }
    public void ShowSettings()
    {
        soundManager.PlayButtonClickSound();
        ShowScenes(settings);
        
    
    }


    public void Vision()
    {
        soundManager.PlayButtonClickSound();
        SceneManager.LoadScene("FinalRoadmap");

    }

    public void QuitApplication()
    {
        soundManager.PlayButtonClickSound();
        Application.Quit();

    }

    public void ShowScenes(GameObject currentScene)
    {

        mainMenu.SetActive(currentScene == mainMenu);
        Story.SetActive(currentScene == Story);
        leaderBoard.SetActive(currentScene == leaderBoard);
        
        levelScene.SetActive(currentScene == levelScene);
        roverSelection.SetActive(currentScene == roverSelection);
        
        logo.SetActive(currentScene == logo);
        settings.SetActive(currentScene == settings);


        // Deactivate all other UI elements
        if (currentScene != mainMenu)
            mainMenu.SetActive(false);
        if (currentScene != Story)
            Story.SetActive(false);
        if (currentScene != leaderBoard)
            leaderBoard.SetActive(false);
       
        if (currentScene != levelScene)
            levelScene.SetActive(false);
        if (currentScene != roverSelection)
            roverSelection.SetActive(false);
        
        if (currentScene != logo)
            logo.SetActive(false);
        if (currentScene != settings)
            settings.SetActive(false);
        soundManager.PlayButtonClickSound();
    }
}
