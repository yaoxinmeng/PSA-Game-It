using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATV : MonoBehaviour {

    [Range(0, 20f)]
    public float patrolSpeed;
    public bool isLeft; //check for direction
    public bool isOn;

    private float x; //initial x-coordinate
    private bool changeDirection;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        x = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
        changeDirection = false;
        anim = GetComponent<Animator>();
        if (isLeft)
            transform.Rotate(0, 180, 0); //if ATV moves left initially
    }

    void Update()
    {
        if (isOn)
        {
            gameObject.tag = "Enemy";
            transform.Find("Top Surface").gameObject.tag = "Enemy";
            if (isLeft)
                rb.velocity = new Vector2(-patrolSpeed, 0);
            else
                rb.velocity = new Vector2(patrolSpeed, 0);

            if (changeDirection)
            {
                if (transform.position.x < x)
                {
                    isLeft = false;
                }
                else if (transform.position.x > x)
                {
                    isLeft = true;
                }
                transform.Rotate(0, 180, 0);
                changeDirection = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            gameObject.tag = "Container";
            transform.Find("Top Surface").gameObject.tag = "Container";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        if (obj.gameObject.tag == "Checkpoint")
        {
            if (obj == transform.parent.GetChild(1).GetChild(0).gameObject || obj == transform.parent.GetChild(1).GetChild(1).gameObject)
            {
                changeDirection = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.gameObject.tag == "Checkpoint")
        {
            if (obj == transform.parent.GetChild(1).GetChild(0).gameObject || obj == transform.parent.GetChild(1).GetChild(1).gameObject)
            {
                changeDirection = false;
            }
        }
    }
}
