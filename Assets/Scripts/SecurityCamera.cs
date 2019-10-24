using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour {

    public bool isOn;
    private SpriteRenderer ren;
    private float iniAlpha;

	// Use this for initialization
	void Start () {
        ren = GetComponent<SpriteRenderer>();
        iniAlpha = ren.color.a;
	}

	// Update is called once per frame
	void Update () {
        if (isOn)
        {
            tag = "Enemy";
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, iniAlpha);
        }
        else
        {
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, 0f);
            tag = "Security Camera";
        }
	}
}
