using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDialogs : MonoBehaviour {

	private float startTime;
    private float currentTime;
    [Tooltip("Select a prime number for better effect e.g 7, 11, 13, 17...")]
    public float intervalToShowDialog = 11f;
    public float durationToShowDialog = 3f;
    private int choiceOfDialog;
    private GameObject currentDialog;
    private bool showDialog = true;

	// Use this for initialization
	void Start () {
		for (int n = 0; n < transform.childCount; n++)
        {
            transform.GetChild(n).gameObject.SetActive(false);
        }
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		decideShowDialog();
	}

	void decideShowDialog(){
		currentTime = Time.time - startTime;
		if (Mathf.Round(currentTime) % Mathf.Round(intervalToShowDialog) == 0 && showDialog){
			showDialog = false;
			choiceOfDialog = Random.Range(0, transform.childCount);
			currentDialog = transform.GetChild(choiceOfDialog).gameObject;
			currentDialog.SetActive(true);
			StartCoroutine(closeDialog());
		}
	}

	IEnumerator closeDialog()
     {
         yield return new WaitForSeconds(durationToShowDialog);
         currentDialog.SetActive(false);
         showDialog = true;
     }
}
