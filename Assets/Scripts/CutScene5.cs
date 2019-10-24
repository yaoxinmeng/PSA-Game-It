using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene5 : MonoBehaviour {
    private GameObject game;
    private VideoPlayer vp;

    // Use this for initialization
    void Start()
    {
        game = GameObject.Find("Game");
        vp = GetComponent<VideoPlayer>();
        if (PlayerPrefs.HasKey("Cutscene5"))
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
    void Update()
    {
        if (!vp.isPlaying)
        {
            PlayerPrefs.SetInt("Cutscene5", 1);
            game.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
