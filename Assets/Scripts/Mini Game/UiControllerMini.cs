using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiControllerMini : MonoBehaviour
{
    public static bool gameStart = false;
    public static bool playerDied = false; //toggles true on death, maybe can show cutscene
    public static bool pause = false; // used to pause game
    public static bool nextLevel = false; //checks if level passed
    public static bool options = false;
    //  public static bool surePrompt = false;
    private bool confirm = false;
    private float accumtime = 0f;

    private LevelManager levelManager;
    
    private GameObject optionsMenu;
    private GameObject sureBoPrompt;
    private GameObject pauseButton;
    private GameObject levelComplete;
    private GameObject score;
    private GameObject tutorial;

    private GameObject movementControls;

    private int sceneIndex;

    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        pauseButton = GameObject.Find("GUI/Pause Button");
        movementControls = GameObject.Find("GUI/Movement Controls");
        levelComplete = GameObject.Find("GUI/Level Complete");
        score = GameObject.Find("GUI/Score");
        optionsMenu = GameObject.Find("GUI/Options Menu");
        tutorial = GameObject.Find("GUI/Tutorial");

        //stagePageOne = GameObject.Find("GUI/Stage Select Menu/Page One");
        //stagePageTwo = GameObject.Find("GUI/Stage Select Menu/Page Two");

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        levelComplete.SetActive(false);
        optionsMenu.SetActive(false);
        movementControls.SetActive(false);
        score.SetActive(false);
        pauseButton.SetActive(false);

        gameStart = false;
        playerDied = false;
        pause = false;
        nextLevel = false;
        options = false;
    }

    // Update is called once per frame
    void Update()
    {

        //pre-game instructions
        if (!gameStart)
        {
            //for BGM
            GetComponent<AudioSource>().volume = 0.2f * PlayerPrefs.GetFloat("BGMvolume");

            accumtime += Time.deltaTime;
            if (tutorial.transform.GetChild(0).gameObject.activeInHierarchy && accumtime > 2f)
            {
                tutorial.transform.GetChild(0).gameObject.SetActive(false);
                tutorial.transform.GetChild(1).gameObject.SetActive(true);
                accumtime = 0f;
            }
            else if (tutorial.transform.GetChild(1).gameObject.activeInHierarchy && accumtime > 1f)
            {
                tutorial.transform.GetChild(1).gameObject.SetActive(false);
                tutorial.transform.GetChild(2).gameObject.SetActive(true);
                accumtime = 0f;
            }
            else if (tutorial.transform.GetChild(2).gameObject.activeInHierarchy && accumtime > 1f)
            {
                tutorial.transform.GetChild(2).gameObject.SetActive(false);
                tutorial.transform.GetChild(3).gameObject.SetActive(true);
                accumtime = 0f;
            }
            else if (tutorial.transform.GetChild(3).gameObject.activeInHierarchy && accumtime > 1f)
            {
                tutorial.transform.GetChild(3).gameObject.SetActive(false);
                gameStart = true;
            }
        }
        else if (!playerDied)
        {
            //for BGM
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMvolume");

            pauseButton.SetActive(true);
            movementControls.SetActive(true);
            score.SetActive(true);
            optionsMenu.SetActive(false);
            GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0f);
        }
        else    
        {
            //for BGM
            GetComponent<AudioSource>().volume = 0;

            levelComplete.SetActive(true);
            pauseButton.SetActive(false);
            GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.2f);
            score.SetActive(false);
            movementControls.SetActive(false);
            Invoke("nextStage", 3.5f);
        }

        if (pause)
        {
            Time.timeScale = 0f;
            optionsMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            optionsMenu.SetActive(false);
        }
        
        if (nextLevel)
        {
            Time.timeScale = 1;
            print("Load Next level!");
            levelManager.nextLevel();
        }

        if (options)
        {
            pauseButton.SetActive(false);
            movementControls.SetActive(false);
            optionsMenu.SetActive(true);
        }

        // if (surePrompt){
        //     pauseButton.SetActive(false);
        //     movementControls.SetActive(false);
        //     stageSelectMenu.SetActive(false);
        //     stagePageOne.SetActive(false);
        //     optionsMenu.SetActive(false);
        // }
    }

    // void initialiseVolume(){
    //     if (PlayerPrefs.HasKey("MusicVol") == false){
    //         PlayerPrefs.SetFloat("MusicVol", 0.9f);
    //     }
    //     if (PlayerPrefs.HasKey("SFXVol") == false){
    //         PlayerPrefs.SetFloat("SFXVol", 0.9f);
    //     }
    // }

    public void pauseGame()
    {
        if (pause)
        {
            pause = false;
            print("Resume Game!");
        }
        else
        {

            pause = true;
            print("Pause Game!");
        }
    }

    public void startGame()
    {
        options = false;
        nextLevel = true;
        print("Start Game!");
    }

    public void returnToHome()
    {
        options = false;
        pause = false;
        levelManager.loadHomeScene();
        print("Return to Home View!");
    }
    

    public void toggleOptions()
    {
        if (options)
        {
            options = false;
            print("Close Options");
        }
        else
        {
            options = true;
            print("Options");
        }
    }

    public void reloadLevel()
    {
        if (sceneIndex == 0)
        {
            print("Do not do anything when it's in the main screen. Why would you want to restart when you are in the main screen?!");
        }
        else
        {
            pause = false;
            options = false;
            gameStart = false;
            Time.timeScale = 1;
            levelManager.loadCurrentLevel();
            print("Reload level!");
        }
    }
    
    public void playButton()
    {
        if (sceneIndex == 0)
        {
            if (PlayerPrefs.GetInt("SceneOneStars") != 4)
                levelManager.loadSelectedLevel(1); //goes to video cutscene
            if (PlayerPrefs.GetInt("SceneTwoStars") != 4)
                levelManager.loadSelectedLevel(3);
            if (PlayerPrefs.GetInt("SceneThreeStars") != 4)
                levelManager.loadSelectedLevel(4);
            if (PlayerPrefs.GetInt("SceneFourStars") != 4)
                levelManager.loadSelectedLevel(5);
            if (PlayerPrefs.GetInt("SceneFiveStars") != 4)
                levelManager.loadSelectedLevel(6);
            if (PlayerPrefs.GetInt("SceneSixStars") != 4)
                levelManager.loadSelectedLevel(7);
            if (PlayerPrefs.GetInt("SceneSevenStars") != 4)
                levelManager.loadSelectedLevel(8);
            if (PlayerPrefs.GetInt("SceneMini") != 4)
                levelManager.loadSelectedLevel(9);
        }
        else
        {
            if (options)
            {
                options = false;
                optionsMenu.SetActive(false);
            }
            pauseGame();
        }
    }

    public void nextStage()
    {
        playerDied = false;
        nextLevel = true;
    }


    // For Debugging purposes //
    public void eraseAllData()
    {
        PlayerPrefs.DeleteAll();
        returnToHome();
        print("Cleared all data! Stages back to square 1");
    }

    public void unlock2()
    {
        PlayerPrefs.SetInt("SceneTwoStars", 1);
        returnToHome();
    }

    public void unlock6()
    {
        PlayerPrefs.SetInt("SceneSixStars", 1);
        returnToHome();
    }

    public void loadFinalCut()
    {
        levelManager.loadSelectedLevel(9);
    }
}
