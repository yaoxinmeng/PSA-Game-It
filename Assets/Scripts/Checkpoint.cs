using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private float accumTime = 0;

    public float displacement;
    public float period;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        accumTime += Time.deltaTime;
        if (accumTime < period)
            transform.Translate(Time.deltaTime * displacement, 0, 0);     
        else
        {
            accumTime = 0;
            displacement = -displacement;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
