using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutScene7 : MonoBehaviour
{
    private GameObject game;
    private VideoPlayer vp;

    // Use this for initialization
    void Start()
    {
        game = GameObject.Find("Game");
        vp = GetComponent<VideoPlayer>();
        if (PlayerPrefs.HasKey("Cutscene7"))
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
            PlayerPrefs.SetInt("Cutscene7", 1);
            game.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
