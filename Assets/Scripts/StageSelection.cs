using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ========================================
// Unlock Stars Key Reference
// 0 - 0 star 
// 1 - 1 stars
// 2 - 2 stars
// 3 - 3 stars
// 4 - locked
// ========================================

public class StageSelection : MonoBehaviour {

	private UiController uiController;
	private LevelManager levelManager;
	private float timeTaken;
	private int sceneIndex;
	private string starsKey;

	private GameObject oneStar;
	private GameObject twoStar;
	private GameObject threeStar;

	private GameObject stage10;
	private GameObject stage11;
	private GameObject stage12;
	private GameObject stage13;
	private GameObject stage20;
	private GameObject stage21;
	private GameObject stage22;
	private GameObject stage23;
	private GameObject stage24;
	private GameObject stage30;
	private GameObject stage31;
	private GameObject stage32;
	private GameObject stage33;
	private GameObject stage34;
	private GameObject stage40;
	private GameObject stage41;
	private GameObject stage42;
	private GameObject stage43;
	private GameObject stage44;
	private GameObject stage50;
	private GameObject stage51;
	private GameObject stage52;
	private GameObject stage53;
	private GameObject stage54;
	private GameObject stage60;
	private GameObject stage61;
	private GameObject stage62;
	private GameObject stage63;
	private GameObject stage64;
	private GameObject stage70;
	private GameObject stage71;
	private GameObject stage72;
	private GameObject stage73;
	private GameObject stage74;
	private GameObject stageminilocked;
	private GameObject stageminiunlocked;

	void Start(){
		uiController = GetComponent<UiController>();
		levelManager = GetComponent<LevelManager>();
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		initialiseStars();

		oneStar = GameObject.Find("GUI/Level Completed/Stars/1 Star");
		twoStar = GameObject.Find("GUI/Level Completed/Stars/2 Star");
		threeStar = GameObject.Find("GUI/Level Completed/Stars/3 Star");

		stage10 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 1/Stage 1-0");
		stage11 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 1/Stage 1-1");
		stage12 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 1/Stage 1-2");
		stage13 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 1/Stage 1-3");

		stage20 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 2/Stage 2-0");
		stage21 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 2/Stage 2-1");
		stage22 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 2/Stage 2-2");
		stage23 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 2/Stage 2-3");
		stage24 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 2/Stage 2-4");

		stage30 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 3/Stage 3-0");
		stage31 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 3/Stage 3-1");
		stage32 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 3/Stage 3-2");
		stage33 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 3/Stage 3-3");
		stage34 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 3/Stage 3-4");

		stage40 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 4/Stage 4-0");
		stage41 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 4/Stage 4-1");
		stage42 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 4/Stage 4-2");
		stage43 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 4/Stage 4-3");
		stage44 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 4/Stage 4-4");

		stage50 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 5/Stage 5-0");
		stage51 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 5/Stage 5-1");
		stage52 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 5/Stage 5-2");
		stage53 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 5/Stage 5-3");
		stage54 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 5/Stage 5-4");

		stage60 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 6/Stage 6-0");
		stage61 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 6/Stage 6-1");
		stage62 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 6/Stage 6-2");
		stage63 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 6/Stage 6-3");
		stage64 = GameObject.Find("GUI/Stage Select Menu/Page One/Stage 6/Stage 6-4");

		stage70 = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage 7/Stage 7-0");
		stage71 = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage 7/Stage 7-1");
		stage72 = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage 7/Stage 7-2");
		stage73 = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage 7/Stage 7-3");
		stage74 = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage 7/Stage 7-4");

		stageminilocked = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage Mini/Locked");
		stageminiunlocked = GameObject.Find("GUI/Stage Select Menu/Page Two/Stage Mini/Unlocked");							

	}

	void Update(){
		displayStages();
	}

	void displayStages(){
		switch(PlayerPrefs.GetInt("SceneOneStars")){
			case 0:
				stage10.SetActive(true);
				stage11.SetActive(false);
				stage12.SetActive(false);
				stage13.SetActive(false);
				break;
			case 1:
				stage10.SetActive(false);
				stage11.SetActive(true);
				stage12.SetActive(false);
				stage13.SetActive(false);
				break;
			case 2:
				stage10.SetActive(false);
				stage11.SetActive(false);
				stage12.SetActive(true);
				stage13.SetActive(false);
				break;
			case 3:
				stage10.SetActive(false);
				stage11.SetActive(false);
				stage12.SetActive(false);
				stage13.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneTwoStars")){
			case 0:
				stage20.SetActive(true);
				stage21.SetActive(false);
				stage22.SetActive(false);
				stage23.SetActive(false);
				stage24.SetActive(false);
				break;
			case 1:
				stage20.SetActive(false);
				stage21.SetActive(true); //
				stage22.SetActive(false);
				stage23.SetActive(false);
				stage24.SetActive(false);
				break;
			case 2:
				stage20.SetActive(false);
				stage21.SetActive(false);
				stage22.SetActive(true); //
				stage23.SetActive(false);
				stage24.SetActive(false);
				break;
			case 3:
				stage20.SetActive(false);
				stage21.SetActive(false);
				stage22.SetActive(false);
				stage23.SetActive(true); //
				stage24.SetActive(false);
				break;
			case 4:
				stage20.SetActive(false);
				stage21.SetActive(false);
				stage22.SetActive(false);
				stage23.SetActive(false);
				stage24.SetActive(true); //
				break;
		}

		switch(PlayerPrefs.GetInt("SceneThreeStars")){
			case 0:
				stage30.SetActive(true);
				stage31.SetActive(false);
				stage32.SetActive(false);
				stage33.SetActive(false);
				stage34.SetActive(false);
				break;
			case 1:
				stage30.SetActive(false);
				stage31.SetActive(true);
				stage32.SetActive(false);
				stage33.SetActive(false);
				stage34.SetActive(false);
				break;
			case 2:
				stage30.SetActive(false);
				stage31.SetActive(false);
				stage32.SetActive(true);
				stage33.SetActive(false);
				stage34.SetActive(false);
				break;
			case 3:
				stage30.SetActive(false);
				stage31.SetActive(false);
				stage32.SetActive(false);
				stage33.SetActive(true);
				stage34.SetActive(false);
				break;
			case 4:
				stage30.SetActive(false);
				stage31.SetActive(false);
				stage32.SetActive(false);
				stage33.SetActive(false);
				stage34.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneFourStars")){
			case 0:
				stage40.SetActive(true);
				stage41.SetActive(false);
				stage42.SetActive(false);
				stage43.SetActive(false);
				stage44.SetActive(false);
				break;
			case 1:
				stage40.SetActive(false);
				stage41.SetActive(true);
				stage42.SetActive(false);
				stage43.SetActive(false);
				stage44.SetActive(false);
				break;
			case 2:
				stage40.SetActive(false);
				stage41.SetActive(false);
				stage42.SetActive(true);
				stage43.SetActive(false);
				stage44.SetActive(false);
				break;
			case 3:
				stage40.SetActive(false);
				stage41.SetActive(false);
				stage42.SetActive(false);
				stage43.SetActive(true);
				stage44.SetActive(false);
				break;
			case 4:
				stage40.SetActive(false);
				stage41.SetActive(false);
				stage42.SetActive(false);
				stage43.SetActive(false);
				stage44.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneFiveStars")){
			case 0:
				stage50.SetActive(true);
				stage51.SetActive(false);
				stage52.SetActive(false);
				stage53.SetActive(false);
				stage54.SetActive(false);
				break;
			case 1:
				stage50.SetActive(false);
				stage51.SetActive(true);
				stage52.SetActive(false);
				stage53.SetActive(false);
				stage54.SetActive(false);
				break;
			case 2:
				stage50.SetActive(false);
				stage51.SetActive(false);
				stage52.SetActive(true);
				stage53.SetActive(false);
				stage54.SetActive(false);
				break;
			case 3:
				stage50.SetActive(false);
				stage51.SetActive(false);
				stage52.SetActive(false);
				stage53.SetActive(true);
				stage54.SetActive(false);
				break;
			case 4:
				stage50.SetActive(false);
				stage51.SetActive(false);
				stage52.SetActive(false);
				stage53.SetActive(false);
				stage54.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneSixStars")){
			case 0:
				stage60.SetActive(true);
				stage61.SetActive(false);
				stage62.SetActive(false);
				stage63.SetActive(false);
				stage64.SetActive(false);
				break;
			case 1:
				stage60.SetActive(false);
				stage61.SetActive(true);
				stage62.SetActive(false);
				stage63.SetActive(false);
				stage64.SetActive(false);
				break;
			case 2:
				stage60.SetActive(false);
				stage61.SetActive(false);
				stage62.SetActive(true);
				stage63.SetActive(false);
				stage64.SetActive(false);
				break;
			case 3:
				stage60.SetActive(false);
				stage61.SetActive(false);
				stage62.SetActive(false);
				stage63.SetActive(true);
				stage64.SetActive(false);
				break;
			case 4:
				stage60.SetActive(false);
				stage61.SetActive(false);
				stage62.SetActive(false);
				stage63.SetActive(false);
				stage64.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneSevenStars")){
			case 0:
				stage70.SetActive(true);
				stage71.SetActive(false);
				stage72.SetActive(false);
				stage73.SetActive(false);
				stage74.SetActive(false);
				break;
			case 1:
				stage70.SetActive(false);
				stage71.SetActive(true);
				stage72.SetActive(false);
				stage73.SetActive(false);
				stage74.SetActive(false);
				break;
			case 2:
				stage70.SetActive(false);
				stage71.SetActive(false);
				stage72.SetActive(true);
				stage73.SetActive(false);
				stage74.SetActive(false);
				break;
			case 3:
				stage70.SetActive(false);
				stage71.SetActive(false);
				stage72.SetActive(false);
				stage73.SetActive(true);
				stage74.SetActive(false);
				break;
			case 4:
				stage70.SetActive(false);
				stage71.SetActive(false);
				stage72.SetActive(false);
				stage73.SetActive(false);
				stage74.SetActive(true);
				break;
		}

		switch(PlayerPrefs.GetInt("SceneMini")){
			case 1:	//1 means scene mini unlocked!
				stageminiunlocked.SetActive(true);
				stageminilocked.SetActive(false);
				break;

			case 4:	//4 means scene mini locked!
				stageminiunlocked.SetActive(false);
				stageminilocked.SetActive(true);
				break;
		}
	}

	void initialiseStars() {	//if player has not played the game before, initialise the stars for all stages to 0
		if (PlayerPrefs.HasKey("SceneOneStars") == false){
			PlayerPrefs.SetInt("SceneOneStars", 0);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneTwoStars") == false){
			PlayerPrefs.SetInt("SceneTwoStars", 4);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneThreeStars") == false){
			PlayerPrefs.SetInt("SceneThreeStars", 4);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneFourStars") == false){
			PlayerPrefs.SetInt("SceneFourStars", 4);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneFiveStars") == false){
			PlayerPrefs.SetInt("SceneFiveStars", 4);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneSixStars") == false){
			PlayerPrefs.SetInt("SceneSixStars", 4);
			PlayerPrefs.Save();
		}
		if (PlayerPrefs.HasKey("SceneSevenStars") == false){
			PlayerPrefs.SetInt("SceneSevenStars", 4);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.HasKey("SceneMini") == false){
			PlayerPrefs.SetInt("SceneMini", 4);
			PlayerPrefs.Save();
		}
	}


	public void checkStarsObtained(){
		timeTaken = uiController.currentTime;
		switch(sceneIndex){		
		//according to the scene index, each stage has different timing to get different stars
		//adjust the conditions for acheiving the stars in the respective if statements
			case 2:
				if (timeTaken < 30f){
					PlayerPrefs.SetInt("SceneOneStars", 3);
					if (PlayerPrefs.GetInt("SceneTwoStars") == 4){
						PlayerPrefs.SetInt("SceneTwoStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
					
				else if (timeTaken < 40f){
					PlayerPrefs.SetInt("SceneOneStars", 2);
					if (PlayerPrefs.GetInt("SceneTwoStars") == 4){
						PlayerPrefs.SetInt("SceneTwoStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else {
					PlayerPrefs.SetInt("SceneOneStars", 1);
					if (PlayerPrefs.GetInt("SceneTwoStars") == 4){
						PlayerPrefs.SetInt("SceneTwoStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 3:
				if (timeTaken < 30f){
					PlayerPrefs.SetInt("SceneTwoStars", 3);
					if (PlayerPrefs.GetInt("SceneThreeStars") == 4){
						PlayerPrefs.SetInt("SceneThreeStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 40f){
					PlayerPrefs.SetInt("SceneTwoStars", 2);
					if (PlayerPrefs.GetInt("SceneThreeStars") == 4){
						PlayerPrefs.SetInt("SceneThreeStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneTwoStars", 1);
					if (PlayerPrefs.GetInt("SceneThreeStars") == 4){
						PlayerPrefs.SetInt("SceneThreeStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 4:
				if (timeTaken < 30f){
					PlayerPrefs.SetInt("SceneThreeStars", 3);
					if (PlayerPrefs.GetInt("SceneFourStars") == 4){
						PlayerPrefs.SetInt("SceneFourStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 40f){
					PlayerPrefs.SetInt("SceneThreeStars", 2);
					if (PlayerPrefs.GetInt("SceneFourStars") == 4){
						PlayerPrefs.SetInt("SceneFourStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneThreeStars", 1);
					if (PlayerPrefs.GetInt("SceneFourStars") == 4){
						PlayerPrefs.SetInt("SceneFourStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 5:
				if (timeTaken < 55f){
					PlayerPrefs.SetInt("SceneFourStars", 3);
					if (PlayerPrefs.GetInt("SceneFiveStars") == 4){
						PlayerPrefs.SetInt("SceneFiveStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 65f){
					PlayerPrefs.SetInt("SceneFourStars", 2);
					if (PlayerPrefs.GetInt("SceneFiveStars") == 4){
						PlayerPrefs.SetInt("SceneFiveStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneFourStars", 1);
					if (PlayerPrefs.GetInt("SceneFiveStars") == 4){
						PlayerPrefs.SetInt("SceneFiveStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 6:
				if (timeTaken < 55f){
					PlayerPrefs.SetInt("SceneFiveStars", 3);
					if (PlayerPrefs.GetInt("SceneSixStars") == 4){
						PlayerPrefs.SetInt("SceneSixStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 65f){
					PlayerPrefs.SetInt("SceneFiveStars", 2);
					if (PlayerPrefs.GetInt("SceneSixStars") == 4){
						PlayerPrefs.SetInt("SceneSixStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneFiveStars", 1);
					if (PlayerPrefs.GetInt("SceneSixStars") == 4){
						PlayerPrefs.SetInt("SceneSixStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 7:
				if (timeTaken < 30f){
					PlayerPrefs.SetInt("SceneSixStars", 3);
					if (PlayerPrefs.GetInt("SceneSevenStars") == 4){
						PlayerPrefs.SetInt("SceneSevenStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 40f){
					PlayerPrefs.SetInt("SceneSixStars", 2);
					if (PlayerPrefs.GetInt("SceneSevenStars") == 4){
						PlayerPrefs.SetInt("SceneSevenStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneSixStars", 1);
					if (PlayerPrefs.GetInt("SceneSevenStars") == 4){
						PlayerPrefs.SetInt("SceneSevenStars", 0);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;

			case 8:
				if (timeTaken < 30f){
					PlayerPrefs.SetInt("SceneSevenStars", 3);
					if (PlayerPrefs.GetInt("SceneMini") == 4){
						PlayerPrefs.SetInt("SceneMini", 1);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(true);
				}
				else if (timeTaken < 40f){
					PlayerPrefs.SetInt("SceneSevenStars", 2);
					if (PlayerPrefs.GetInt("SceneMini") == 4){
						PlayerPrefs.SetInt("SceneMini", 1);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(true);
					threeStar.SetActive(false);
				}
				else{
					PlayerPrefs.SetInt("SceneSevenStars", 1);
					if (PlayerPrefs.GetInt("SceneMini") == 4){
						PlayerPrefs.SetInt("SceneMini", 1);
					}
					PlayerPrefs.Save();

					oneStar.SetActive(true);
					twoStar.SetActive(false);
					threeStar.SetActive(false);
				}
				break;
		}
	}

	public void loadStage1(){
		levelManager.loadSelectedLevel(2);
	}

	public void loadStage2(){
		if (PlayerPrefs.GetInt("SceneTwoStars") != 4){
			levelManager.loadSelectedLevel(3);
		}
	}

	public void loadStage3(){
		if (PlayerPrefs.GetInt("SceneThreeStars") != 4){
			levelManager.loadSelectedLevel(4);
		}
	}

	public void loadStage4(){
		if (PlayerPrefs.GetInt("SceneFourStars") != 4){
			levelManager.loadSelectedLevel(5);
		}
	}

	public void loadStage5(){
		if (PlayerPrefs.GetInt("SceneFiveStars") != 4){
			levelManager.loadSelectedLevel(6);
		}
	}

	public void loadStage6(){
		if (PlayerPrefs.GetInt("SceneSixStars") != 4){
			levelManager.loadSelectedLevel(7);
		}
	}

	public void loadStage7(){
		if (PlayerPrefs.GetInt("SceneSevenStars") != 4){
			levelManager.loadSelectedLevel(8);
		}
	}

	public void loadFinalStage(){
		if (PlayerPrefs.GetInt("SceneMini") != 4){
			levelManager.loadSelectedLevel(9);
		}
	}
}
