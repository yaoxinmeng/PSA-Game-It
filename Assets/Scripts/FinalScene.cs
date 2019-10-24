using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour {

	private LevelManager levelManager;
	private UnityEngine.Video.VideoPlayer vp;
	// Use this for initialization
	void Awake () {
		levelManager = GetComponent<LevelManager>();
		vp = GetComponent<UnityEngine.Video.VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		Invoke("checkIfFinished", 1f);
	}

	void checkIfFinished(){
		if (vp.isPlaying == false){
			levelManager.loadSelectedLevel(0);
		}
	}
}
