using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSecurityCamera : MonoBehaviour {

	public float rotatingSpeed;
	private bool flip = false;
	public float leftLimitRotation = -45f;
	public float rightLimitRotation = 45f;
    private SpriteRenderer ren;
    private float iniAlpha;

    public bool isOn;

    void Start()
    {
        ren = transform.GetChild(0).GetComponent<SpriteRenderer>();
        iniAlpha = ren.color.a;
    }

    // Update is called once per frame
    void Update ()
	{
        if (isOn)
        {
            float angle = transform.localEulerAngles.z;
            angle = (angle > 180) ? angle - 360 : angle;
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, iniAlpha);

            if (angle > rightLimitRotation)
            {
                rotatingSpeed = -1f * rotatingSpeed;
            }

            if (angle < leftLimitRotation)
            {
                rotatingSpeed = -1f * rotatingSpeed;
            }

            transform.Rotate(0f, 0f, -rotatingSpeed * Time.deltaTime);
            tag = "Enemy";
            transform.GetChild(0).tag = "Enemy";
        }
        else
        {
            tag = "Security Camera";
            transform.GetChild(0).tag = "Security Camera";
            transform.Rotate(0, 0, 0);
            ren.color = new Vector4(ren.color.r, ren.color.g, ren.color.b, 0f);
        }
	}
}
