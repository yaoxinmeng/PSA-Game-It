using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletion : MonoBehaviour {
    public GameObject score;

    private float accumtime = 0;
    private float a = 0.01f;
    private bool wasOff = true;

	// Use this for initialization
	void Start () {
        
    }

	
	// Update is called once per frame
	void Update () {
        if(isActiveAndEnabled && wasOff)
        {
            GetComponent<Text>().text = GetComponent<Text>().text + " Score: " + score.GetComponent<Text>().text;
            wasOff = false;
        }

        accumtime += Time.deltaTime;
        if (accumtime > 0.1 && GetComponent<Text>().fontSize < 90)
        {
            GetComponent<Text>().fontSize += 6;
            a += a;
            accumtime = a;
        }
	}
}
