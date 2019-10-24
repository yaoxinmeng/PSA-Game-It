using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Tutorial : MonoBehaviour
{

    //Crane tutorial
    public GameObject mainChar;

    // Use this for initialization
    void Start()
    {
        //For crane
        if (transform.Find("Crane Tutorial") != null)
            transform.Find("Crane Tutorial").gameObject.SetActive(false);

        //checks if tutorial has been completed previously
        if (PlayerPrefs.GetInt("Tutorial 4") == 1)
            transform.GetChild(0).gameObject.SetActive(false);
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            UiController.tutorialOn = true;
        }
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            if (!UiController.tutorialOn)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Tutorial 4", 1);
            }
        }

        if (GuiController.canDismiss)
            transform.GetChild(1).gameObject.SetActive(true);
        else
            transform.GetChild(1).gameObject.SetActive(false);

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
