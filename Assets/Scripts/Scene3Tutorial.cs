using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Tutorial : MonoBehaviour {
    
    //Crane tutorial
    public GameObject mainChar;

    // Use this for initialization
    void Start()
    {
        //checks if tutorial has been completed previously
        if (PlayerPrefs.GetInt("Tutorial 3") == 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            UiController.tutorialOn = true;
        }
        transform.GetChild(2).gameObject.SetActive(false);
        
        //Crane trivia
        if (transform.Find("Crane Tutorial") != null)
            transform.Find("Crane Tutorial").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //For Tutorial 1
        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            if (!UiController.tutorialOn)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                UiController.tutorialOn = true;
            }
        }

        //For Tutorial 2
        if (transform.GetChild(1).gameObject.activeInHierarchy)
        {
            if (!UiController.tutorialOn)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Tutorial 3", 1);
            }
        }
        
        if (GuiController.canDismiss)
            transform.GetChild(2).gameObject.SetActive(true);
        else
            transform.GetChild(2).gameObject.SetActive(false);
        
        //For crane trivia
        if (mainChar.GetComponent<MainChar2D>().onCrane)
            transform.Find("Crane Tutorial").gameObject.SetActive(true);
        else
        {
            transform.Find("Crane Tutorial").gameObject.SetActive(false);
            CraneTutorial.n = 0;
        }
    }
}
