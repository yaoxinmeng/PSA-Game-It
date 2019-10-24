using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraMini : MonoBehaviour {

    private bool isOn = false;
    private SpriteRenderer ren;
    private float iniAlpha;
    private float accumtime = 0;

    public float onTime;
    public float offTime;

    // Use this for initialization
    void Start () {
        ren = GetComponent<SpriteRenderer>();
        iniAlpha = ren.color.a;
    }
	
	// Update is called once per frame
	void Update () {
        accumtime += Time.deltaTime;
        if(accumtime > offTime && !isOn)
        {
            isOn = true;
            accumtime = 0;
        }
        if (accumtime > onTime && isOn)
        {
            isOn = false;
            accumtime = 0;
        }
        if (isOn)
        {
            tag = "Enemy";
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, iniAlpha);
        }
        else
        {
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, 0.1f);
            tag = "Untagged";
        }
    }
}
