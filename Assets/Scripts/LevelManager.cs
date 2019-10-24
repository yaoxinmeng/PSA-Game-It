using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int sceneIndex;

	void Start() {
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	public void nextLevel () {
		SceneManager.LoadScene (sceneIndex + 1);
		UiController.nextLevel = false;
		UiController.gameClear = false;
	}

	public void loadHomeScene(){
		SceneManager.LoadScene (0);		//assuming home scene still has build index of 0
		UiController.nextLevel = false;
	}

	public void loadCurrentLevel(){
		SceneManager.LoadScene(sceneIndex);
	}

	public void loadSelectedLevel(int scene){
		SceneManager.LoadScene(scene);
		UiController.stageSelect = false;
		UiController.options = false;
		UiController.pause = false;
	}

}
