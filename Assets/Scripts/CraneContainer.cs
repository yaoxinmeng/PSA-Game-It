using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneContainer : MonoBehaviour {

    private Rigidbody2D rb;
    
    public bool hasPlayer = false;

    // Use this for initialization
    void Start () {
        rb = GetComponentInParent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity == Vector2.zero || hasPlayer)
            transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
        else
            transform.parent.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(rb.velocity.y < 0 && other.gameObject.tag == "Player")
        {
            UiController.playerDied = true;
            print("Player died");
        }
    }
}
