using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene2 : MonoBehaviour {
    private GameObject game;
    private VideoPlayer vp;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("Game");
        vp = GetComponent<VideoPlayer>();
        if (PlayerPrefs.HasKey("Cutscene2"))
        {
            game.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            game.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (!vp.isPlaying)
        {
            PlayerPrefs.SetInt("Cutscene2", 1);
            game.SetActive(true);
            gameObject.SetActive(false);
        }
	}
}
