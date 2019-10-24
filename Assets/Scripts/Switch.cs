using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    List<GameObject> objList = new List<GameObject>();
    private bool triggerswitch = false;

    [Range (0f, 90f)]
    public float switchAngle;

	// Use this for initialization
	void Start () {
        //gets all children that are to be switched on/off
        foreach (Transform child in transform.parent)
        {
            if (child != transform && child != transform.Find("Switch Sprite"))
                objList.Add(child.gameObject);
        }
	}


	// Update is called once per frame
	void Update () {
		if (triggerswitch)
        {
            foreach (GameObject obj in objList)
            {
                switch (obj.tag)
                {
                    case "Crane":
                        obj.transform.Find("Crane").Find("Control Base").Find("Cable And Hook").GetComponent<Crane>().isOn = !obj.transform.Find("Crane").Find("Control Base").Find("Cable And Hook").GetComponent<Crane>().isOn;
                        break;
                    case "Security Camera":
                        obj.GetComponentInChildren<SecurityCamera>().isOn = !obj.GetComponentInChildren<SecurityCamera>().isOn;
                        break;
                    case "Rotating Camera":
                        obj.transform.Find("Pivot").GetChild(0).GetComponent<RotatingSecurityCamera>().isOn = !obj.transform.Find("Pivot").GetChild(0).GetComponent<RotatingSecurityCamera>().isOn;
                        break;
                    case "ATV":
                        obj.transform.Find("ATV").GetComponent<ATV>().isOn = !obj.transform.Find("ATV").GetComponent<ATV>().isOn;
                        break;
                    default:
                        break;
                }
            }
            triggerswitch = false;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        if (obj.tag == "Player")
        {
            if (obj.transform.position.x < transform.position.x && transform.rotation.z >= 0)
            {
                transform.Rotate(0, 0, -switchAngle);
                triggerswitch = true;
                switchAngle = -switchAngle;
            }
            if (obj.transform.position.x > transform.position.x && transform.rotation.z < 0)
            {
                transform.Rotate(0, 0, -switchAngle);
                triggerswitch = true;
                switchAngle = -switchAngle;
            }
        }
    }
}
