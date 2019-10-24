using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour {

    public bool isLeft = false;
    private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        if (isLeft)
            anim.SetBool("isLeft", true);
        else
        	  anim.SetBool("isLeft", false);
	}

	// Update is called once per frame
	void Update () {
		if (isLeft)
            anim.SetBool("isLeft", true);
        else
        	  anim.SetBool("isLeft", false);
	}
}
