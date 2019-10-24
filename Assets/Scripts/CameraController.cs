using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform cam_position;
    public GameObject main_char;
	// Use this for initialization
	void Start () {
        cam_position = GetComponent<Transform>();
        cam_position.position = new Vector3(main_char.GetComponent<Transform>().position.x, main_char.GetComponent<Transform>().position.y, -10);
    }
	
	// Update is called once per frame
	void Update () {
        cam_position.position = new Vector3(main_char.GetComponent<Transform>().position.x, main_char.GetComponent<Transform>().position.y, -10);
    }
}
