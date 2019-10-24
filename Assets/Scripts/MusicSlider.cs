using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("BGMvolume"))
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGMvolume");
        } else {
            PlayerPrefs.SetFloat("BGMvolume", 0.9f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void setVolume(float newvolume)
    {
        PlayerPrefs.SetFloat("BGMvolume", newvolume);
    }
}
