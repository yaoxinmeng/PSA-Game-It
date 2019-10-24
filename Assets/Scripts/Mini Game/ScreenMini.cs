using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMini : MonoBehaviour {
    private Rigidbody2D rb;

    [Range(0, 2)]
    public float initialspeed;
    [Range(0, 10)]
    public float finalspeed;
    [Range(0, 1)]
    public float acceleration;
    [Range(0, 10)]
    public float timedelay;

    private float accumtime = 0f;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(initialspeed, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (UiControllerMini.playerDied || !UiControllerMini.gameStart)
            rb.velocity = Vector2.zero;
        else
        {
            accumtime += Time.deltaTime;
            rb.velocity = new Vector2(initialspeed, 0f);
            if (accumtime > timedelay)
            {
                if (initialspeed < finalspeed)
                {
                    initialspeed += acceleration;
                    rb.velocity = new Vector2(initialspeed, 0f);
                }
                accumtime = 0f;
            }
        }
    }
}
