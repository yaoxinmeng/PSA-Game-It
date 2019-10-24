using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScreenMini : MonoBehaviour {

    public float forceOnPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "ContainerMini" || obj.tag == "Background" || obj.tag == "Ground")
            Destroy(obj);
        if (obj.tag == "Security Camera")
            Destroy(obj.transform.parent.gameObject);

    }
}
