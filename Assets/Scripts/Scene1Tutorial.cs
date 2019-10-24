using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Tutorial : MonoBehaviour {

    public GameObject tutorialWall;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;


    private float accumtime;
    private int n = 0;

    //Tutorial 1
    private bool tutorial1 = true;

    //Tutorial 2
    private bool tutorial2 = false;

    //Tutorial 3
    private bool tutorial3 = false;

    //Tutorial 4
    private bool zoomedIn = false;
    private bool zoomedOut = false;
    private bool tutorial4 = false;

    //Tutorial 5
    private bool tutorial5 = false;

    //Tutorial 6
    private bool tutorial6 = false;

    // Use this for initialization
    void Start () {
        //checks if tutorial has been completed previously
        if (PlayerPrefs.GetInt("Tutorial 1") == 1)
        {
            tutorialWall.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            for (int x = 1; x < transform.childCount; x++)
            {
                transform.GetChild(x).gameObject.SetActive(false);
            }
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
            UiController.tutorialOn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!UiController.tutorialOn)
        {
            for (int x = 0; x < transform.childCount; x++)
            {
                transform.GetChild(x).gameObject.SetActive(false);
            }
        }

        // For Tutorial 1
        if (!arrow1.activeInHierarchy && tutorial1 && !tutorial2)
        {
            UiController.tutorialOn = true;
            transform.GetChild(1).gameObject.SetActive(true);
            arrow2.SetActive(true);
            tutorial2 = true;
        }

        // For Tutorial 2
        if (!arrow2.activeInHierarchy && tutorial2 && !tutorial3)
        {
            UiController.tutorialOn = true;
            transform.GetChild(2).gameObject.SetActive(true);
            arrow3.SetActive(true);
            tutorial3 = true;
        }

        // For Tutorial 3
        if (!arrow3.activeInHierarchy && tutorial3 && !tutorial4)
        {
            UiController.tutorialOn = true;
            transform.GetChild(3).gameObject.SetActive(true);
            tutorial4 = true;
        }

        // For Tutorial 4
        if (GuiController.zoomed)
            zoomedIn = true;
        if (zoomedIn && !GuiController.zoomed)
            zoomedOut = true;
        if (zoomedOut && zoomedIn && tutorial4 && !tutorial5)
        {
            UiController.tutorialOn = true;
            GuiController.zoomed = false;
            transform.GetChild(4).gameObject.SetActive(true);
            tutorialWall.SetActive(false);
            tutorial5 = true;
        }

        //For Tutorial 5
        if (!UiController.tutorialOn && tutorial5 && !tutorial6)
        {
            UiController.tutorialOn = true;
            transform.GetChild(5).gameObject.SetActive(true);
            tutorial6 = true;
        }
        
        //For Tutorial 6
        if (tutorial6 && !UiController.tutorialOn)
        {
            transform.GetChild(5).gameObject.SetActive(false);
        }
        
        if (GuiController.canDismiss)
            transform.GetChild(6).gameObject.SetActive(true);
        else
            transform.GetChild(6).gameObject.SetActive(false);
    }
}
