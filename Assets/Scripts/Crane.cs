using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour { 
    [Range (0, 10)]
    public float speed;
    
    private GameObject craneContainer;
    
    private Rigidbody2D rbBase;
    private Rigidbody2D rbHook;
    private bool up = false;
    private bool down = false;
    private bool left = false;
    private bool right = false;
    
    [HideInInspector]
    public bool hasContainer = false;
    public bool isOn;

    // Use this for initialization
    void Start () {
        rbBase = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        rbHook = GetComponent<Rigidbody2D>();
        
        craneContainer = transform.parent.parent.parent.Find("CraneContainer").gameObject;

        left = true;
        untrapPlayer();
    }
	
	// Update is called once per frame
	void Update () {
        if (UiController.sceneIndex == 1)
            GetComponent<AudioSource>().volume = 0;
        else
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFXvolume") * GetComponent<AudioSource>().volume;

        if (isOn)
        {
            if (up)
            {
                rbHook.velocity = new Vector2(0, speed);
                rbBase.velocity = Vector2.zero;
            }

            else if (down)
            {
                rbBase.velocity = Vector2.zero;
                rbHook.velocity = new Vector2(0, -speed);
            }

            else if (left)
            {
                rbHook.velocity = new Vector2(-speed, 0);
                rbBase.velocity = new Vector2(-speed, 0);
            }

            else if (right)
            {
                rbHook.velocity = new Vector2(speed, 0);
                rbBase.velocity = new Vector2(speed, 0);
            }

            else
            {
                rbBase.velocity = Vector2.zero;
                rbHook.velocity = Vector2.zero;
            }
        }
        else
        {
            rbBase.velocity = Vector2.zero;
            rbHook.velocity = Vector2.zero;
        }

        if (hasContainer)
            craneContainer.GetComponent<Rigidbody2D>().velocity = rbHook.velocity;

        if (craneContainer.GetComponent<BoxCollider2D>().isTrigger)
            untrapPlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Bottom Left Anchor" || obj.tag == "Bottom Right Anchor")
        {
            if(obj == transform.parent.parent.parent.Find("Crane BLeft Anchor").gameObject || obj == transform.parent.parent.parent.Find("Crane BRight Anchor").gameObject)
            {
                up = true;
                down = false;
                rbHook.velocity = new Vector2(0, speed);

                if (hasContainer)
                {
                    craneContainer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    hasContainer = false;
                    untrapPlayer();
                }
                else
                {
                    craneContainer.GetComponent<Rigidbody2D>().velocity = rbHook.velocity;
                    hasContainer = true;
                    trapPlayer();
                }

                GetComponent<Collider2D>().enabled = false;
                Invoke("resetcollider", 0.5f);
            }
        }
        else if (obj.tag == "Top Left Anchor" && obj == transform.parent.parent.parent.Find("Crane TLeft Anchor").gameObject)
        {
            if (up)
            {
                if(hasContainer)
                {
                    right = true;
                    up = false;
                }
                else
                {
                    down = true;
                    up = false;
                }
            }
            if (left)
            {
                down = true;
                left = false;
            }
        }
        else if (obj.tag == "Top Right Anchor" && obj == transform.parent.parent.parent.Find("Crane TRight Anchor").gameObject)
        {
            if (up)
            {
                if (hasContainer)
                {
                    left = true;
                    up = false;
                }
                else
                {
                    down = true;
                    up = false;
                }
            }
            if (right)
            {
                down = true;
                right = false;
            }
        }
    }

    void resetcollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    void trapPlayer()
    {
        transform.Find("Left Sub Arm").GetComponent<BoxCollider2D>().enabled = true;
        transform.Find("Right Sub Arm").GetComponent<BoxCollider2D>().enabled = true;
    }

    void untrapPlayer()
    {
        transform.Find("Left Sub Arm").GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Right Sub Arm").GetComponent<BoxCollider2D>().enabled = false;
    }
}
