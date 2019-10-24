using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMini : MonoBehaviour {
    public GameObject screen;
    public float screenVelocity;
    public float score = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        screenVelocity = screen.GetComponent<ScreenMini>().initialspeed;
        if (!UiControllerMini.playerDied)
        {
            score += screenVelocity * Time.deltaTime;
            GetComponent<Text>().text = "" + (int)score;
        }
	}
}
