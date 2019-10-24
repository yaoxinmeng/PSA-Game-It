using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("SFXvolume")){
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXvolume");
        } else {
            PlayerPrefs.SetFloat("SFXvolume", 0.9f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void setVolume(float newvolume)
    {
        PlayerPrefs.SetFloat("SFXvolume", newvolume);
    }
}
