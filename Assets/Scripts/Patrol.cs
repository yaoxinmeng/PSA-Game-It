using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [Range(1f, 5f)]
    public float patrolSpeed;
    public bool isLeft; //check for direction

    private float x; //initial x-coordinate
    private bool changeDirection;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        x = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        changeDirection = false;
        anim.SetBool("isPatrollingLeft", false);

        if (isLeft)
        	anim.SetBool("isPatrollingLeft", true);
        //    transform.Rotate(0, 180, 0); //if guard moves left initially
    }

    void Update ()
	{
		if (isLeft) {
			anim.SetBool("isPatrollingLeft", true);
			rb.velocity = new Vector2 (-patrolSpeed, 0);
		} else {
			anim.SetBool("isPatrollingLeft", false);
			rb.velocity = new Vector2(patrolSpeed, 0);
		}

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
            //transform.Rotate(0, 180, 0);
            changeDirection = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        if (obj.gameObject.tag == "Checkpoint")
        {
            if(obj == transform.parent.GetChild(1).GetChild(0).gameObject || obj == transform.parent.GetChild(1).GetChild(1).gameObject)
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
