using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene4 : MonoBehaviour
{
    private GameObject game;
    private VideoPlayer vp;

    // Use this for initialization
    void Start()
    {
        game = GameObject.Find("Game");
        vp = GetComponent<VideoPlayer>();
        if (PlayerPrefs.HasKey("Cutscene4"))
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
            PlayerPrefs.SetInt("Cutscene4", 1);
            game.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
