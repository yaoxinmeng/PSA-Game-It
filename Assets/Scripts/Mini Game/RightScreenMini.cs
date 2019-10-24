using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScreenMini : MonoBehaviour {

    public GameObject container;
    public GameObject securitycamera;
    public GameObject securitycamera2;
    public GameObject background;
    public GameObject foreground;

    public float yOffsetContainer;
    public float xOffsetContainer;
    public float yOffsetTopCamera;
    public float yOffsetBotCamera;
    public float iniMinCameraGap;
    public float finMinCameraGap;
    public float altCameraProb;
    public float xOffsetBg;
    public float yOffsetBg;
    public float xOffsetFore;
    public float yOffsetFore;

    public int cameraTime;
    
    private float decreaseGap;

    // Use this for initialization
    void Start () {
        if (iniMinCameraGap > finMinCameraGap)
            decreaseGap = (iniMinCameraGap - finMinCameraGap) / cameraTime;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ContainerMini")
        {
            Instantiate(container, new Vector2(transform.position.x + xOffsetContainer, transform.position.y + yOffsetContainer), Quaternion.identity);
        }

        if (other.gameObject.tag == "Security Camera")
        {
            float x = Random.Range(iniMinCameraGap, 2 * iniMinCameraGap);

            if (iniMinCameraGap > finMinCameraGap)
                iniMinCameraGap = iniMinCameraGap - decreaseGap;

            if(Random.value > altCameraProb)
            {
                if (Random.value < 0.5)
                {
                    Instantiate(securitycamera, new Vector2(transform.position.x + x, transform.position.y + yOffsetBotCamera), Quaternion.identity);
                }
                else
                {
                    Instantiate(securitycamera, new Vector2(transform.position.x + x, transform.position.y + yOffsetTopCamera), Quaternion.identity);
                }
            }
            else
            {
                Instantiate(securitycamera2, new Vector2(transform.position.x + x, transform.position.y + yOffsetTopCamera), Quaternion.identity);
            }
        }

        if (other.gameObject.tag == "Background")
        {
            Instantiate(background, new Vector2(transform.position.x + xOffsetBg, transform.position.y + yOffsetBg), Quaternion.identity);
        }

        if (other.gameObject.tag == "Ground")
        {
            Instantiate(foreground, new Vector2(transform.position.x + xOffsetFore, transform.position.y + yOffsetFore), Quaternion.identity);
        }
    }
}
