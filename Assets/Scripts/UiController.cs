using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour {

    public static bool playerDied = false; //toggles true on death, maybe can show cutscene
    public static bool pause = false; // used to pause game
    public static bool nextLevel = false; //checks if level passed
    public static bool stageSelect = false;
    public static bool options = false;
    public static bool gameClear = false;
    public static bool dying = false;

    //For all tutorials
    public static bool tutorialOn = false;

    //For intermediate cutscene
    private GameObject videoPlayer;

    //  public static bool surePrompt = false;
    private bool confirm = false;
    private bool deathmenu = false;

    private LevelManager levelManager;
    private StageSelection stageSelection;

    private GameObject startMenu;
    private GameObject pauseMenu;
    private GameObject optionsMenu;
    private GameObject stageSelectMenu;
    private GameObject sureBoPrompt;
    private GameObject pauseButton;
    private GameObject completionScreen;
    private GameObject dieMenu;
    private GameObject zoomButton;

    private GameObject movementControls;

    public GameObject stagePageOne;
    public GameObject stagePageTwo;

    public GameObject timingTopLeft;
    public Text pauseTiming;
    public Text levelCompletionTiming;
    public Text deadTiming;
    
    public static int sceneIndex;
    
    public float currentTime;

    void Start() {
        levelManager = GetComponent<LevelManager>();
        stageSelection = GetComponent<StageSelection>();
        completionScreen = GameObject.Find("GUI/Level Completed");
        startMenu = GameObject.Find("GUI/Start Menu");
        pauseButton = GameObject.Find("GUI/Pause Button");
        pauseMenu = GameObject.Find("GUI/Pause Menu");
        movementControls = GameObject.Find("GUI/Movement Controls");
        stageSelectMenu = GameObject.Find("GUI/Stage Select Menu");
        dieMenu = GameObject.Find("GUI/Die Screen");
        optionsMenu = GameObject.Find("GUI/Options Menu");
        zoomButton = GameObject.Find("GUI/Movement Controls/Zoom Button");

        //for cutscenes
        if (GameObject.Find("GUI/Movement Controls/Zoom Button") != null)
            videoPlayer = GameObject.Find("GUI/Video Player");
        else
            videoPlayer = null;

        //stagePageOne = GameObject.Find("GUI/Stage Select Menu/Page One");
        //stagePageTwo = GameObject.Find("GUI/Stage Select Menu/Page Two");

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        pauseTiming = GameObject.Find("Time Taken").GetComponent<Text>();
        currentTime = 0f;

        if (sceneIndex == 0)
        {
            startMenu.SetActive(true);
            pauseButton.SetActive(false);
            timingTopLeft.SetActive(false);
            movementControls.SetActive(false);
            stageSelectMenu.SetActive(false);
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            completionScreen.SetActive(false);
            dieMenu.SetActive(false);
            zoomButton.SetActive(false);
        }
        else
        {
            pauseButton.SetActive(true);
            timingTopLeft.SetActive(true);
            startMenu.SetActive(false);
            movementControls.SetActive(true);
            stageSelectMenu.SetActive(false);
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            completionScreen.SetActive(false);
            dieMenu.SetActive(false);
            zoomButton.SetActive(true);
        }
    }

	// Update is called once per frame
	void Update () {
        if (playerDied)
        {
            if (!deathmenu)
            {
                Invoke("deathMenu", 2f);
                deathmenu = true;
            }

            //for BGM
            GetComponent<AudioSource>().volume = 0;
            GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.2f);
        }
        else
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMvolume");

            if (sceneIndex == 0)
            {
                GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.3f);
            }
            else
            {
                if (videoPlayer != null) //if there is no video player attached
                {
                    if (videoPlayer.activeInHierarchy) //executes when video player is active
                    {
                        timingTopLeft.SetActive(false);
                        movementControls.SetActive(false);
                        zoomButton.SetActive(false);
                        pauseButton.SetActive(false);
                    }
                    else if (tutorialOn) //checks for tutorial
                    {
                        GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.3f);
                        timingTopLeft.SetActive(false);
                        movementControls.SetActive(false);
                        zoomButton.SetActive(false);
                        pauseButton.SetActive(true);
                    }
                    else //no tutorial
                    {
                        GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0f);
                        timingTopLeft.SetActive(true);
                        movementControls.SetActive(true);
                        zoomButton.SetActive(true);
                        pauseButton.SetActive(true);
                    }
                }
                else //if there is a video player attached
                {
                    if (tutorialOn) //checks for tutorial
                    {
                        GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.3f);
                        timingTopLeft.SetActive(false);
                        movementControls.SetActive(false);
                        zoomButton.SetActive(false);
                        pauseButton.SetActive(true);
                    }
                    else //no tutorial
                    {
                        GetComponent<Image>().color = new Vector4(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0f);
                        timingTopLeft.SetActive(true);
                        movementControls.SetActive(true);
                        zoomButton.SetActive(true);
                        pauseButton.SetActive(true);
                    }
                }
            }

            //controls time
            if (videoPlayer != null)
            {
                if (pause || tutorialOn || videoPlayer.activeInHierarchy) { }
                else
                    showTimeTaken();
            }
            else
            {
                if (pause || tutorialOn) { }
                else
                    showTimeTaken();
            }
            

            //executes pause
            if (pause) 
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }

            if (gameClear)
            {
                Time.timeScale = 0;
                stageSelection.checkStarsObtained();
                completionScreen.SetActive(true);
                timingTopLeft.SetActive(false);
                movementControls.SetActive(false);
                zoomButton.SetActive(false);
                pauseButton.SetActive(false);
            }

            if (nextLevel)
            {
                Time.timeScale = 1;
                completionScreen.SetActive(false);
                print("Load Next level!");
                levelManager.nextLevel();
            }

            if (stageSelect)
            {
                startMenu.SetActive(false);
                pauseButton.SetActive(true);
                movementControls.SetActive(false);
                stageSelectMenu.SetActive(true);
                stagePageOne.SetActive(true);
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                completionScreen.SetActive(false);
                dieMenu.SetActive(false);
            }

            if (options)
            {
                startMenu.SetActive(false);
                pauseButton.SetActive(true);
                movementControls.SetActive(false);
                stageSelectMenu.SetActive(false);
                stagePageOne.SetActive(true);
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(true);
                completionScreen.SetActive(false);
                dieMenu.SetActive(false);
            }
        }



        // if (surePrompt){
        //     startMenu.SetActive(false);
        //     pauseButton.SetActive(false);
        //     movementControls.SetActive(false);
        //     stageSelectMenu.SetActive(false);
        //     stagePageOne.SetActive(false);
        //     pauseMenu.SetActive(false);
        //     optionsMenu.SetActive(false);
        //     completionScreen.SetActive(false);
        // }
    }

    public void closeScreen()
    {
        if (options)
        {
            options = false;
            optionsMenu.SetActive(false);
        }
        if (stageSelect)
        {
            stageSelect = false;
            stageSelectMenu.SetActive(false);
        }

        if (sceneIndex == 0)
            startMenu.SetActive(true);
        else
            pause = true;
    }

    public void pauseGame() {
        if (pause) {
            pause = false;
            print("Resume Game!");
        } else {
            
            pause = true;
            print("Pause Game!");
        }
    }

    public void startGame() {
        options = false;
        nextLevel = true;
        print("Start Game!");
    }

    public void toggleSelectStage(){
        if(stageSelect){
            stageSelect = false;
        } else {
            dying = false;
            options = false;
            stageSelect = true;
            print("Select Stage");
        }
    }

    public void returnToHome(){
        options = false;
        stageSelect = false;
        pause = false;
        playerDied = false;
        levelManager.loadHomeScene();
        print("Return to Home View!");
    }

    //for controlling the stage select menu
    public void previousPage(){
        stagePageOne.SetActive(!stagePageOne.activeInHierarchy);
        print("show page 1!");
        stagePageTwo.SetActive(false);
    }

    public void nextPage(){
        if (stagePageTwo.activeInHierarchy == false){
            stagePageOne.SetActive(!stagePageOne.activeInHierarchy);
            print("show page 2!");
            stagePageTwo.SetActive(true);
        }
    }

    public void toggleOptions(){
        if (options){
            options = false;
            print("Close Options");
        } else {
            stageSelect = false;
            options = true;
            print("Options");
        }
    }

    public void reloadLevel(){
        if (sceneIndex == 0){
            print("Do not do anything when it's in the main screen. Why would you want to restart when you are in the main screen?!");
        } else {
            pause = false;
            options = false;
            gameClear = false;
            Time.timeScale = 1;
            playerDied = false;
            levelManager.loadCurrentLevel();
            print("Reload level!");
        }
    }

    private void showTimeTaken(){
        currentTime += Time.deltaTime;
        currentTime = Mathf.Round(currentTime * 100f) / 100f;
        pauseTiming.text = currentTime.ToString();
        levelCompletionTiming.text = currentTime.ToString();
        timingTopLeft.GetComponentInChildren<Text>().text = currentTime.ToString();
        deadTiming.text = currentTime.ToString();
    }

    public void playButton()
    {
        if (sceneIndex == 0)
        {
            if(PlayerPrefs.GetInt("SceneOneStars") != 4)
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
        else {
            if (options){
                options = false;
                optionsMenu.SetActive(false);
            }
            pauseGame();
        }
    }

    public void nextStage(){
        nextLevel = true;
    }

    public void deathMenu()
    {
        dieMenu.SetActive(true);
    }


// For Debugging purposes //
    public void eraseAllData(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        returnToHome();
        print("Cleared all data! Stages back to square 1");
    }

    public void loadFinalCut(){
        levelManager.loadSelectedLevel(10);
    }

    public void unlockAll(){
        PlayerPrefs.SetInt("watchedIntro", 1);
        PlayerPrefs.SetInt("SceneMini", 1);
        PlayerPrefs.SetInt("SceneSevenStars", 3);
        PlayerPrefs.SetInt("SceneSixStars", 3);
        PlayerPrefs.SetInt("SceneFiveStars", 3);
        PlayerPrefs.SetInt("SceneFourStars", 3);
        PlayerPrefs.SetInt("SceneThreeStars", 3);
        PlayerPrefs.SetInt("SceneTwoStars", 3);
        PlayerPrefs.SetInt("SceneOneStars", 3);
        PlayerPrefs.Save();
    }
}
