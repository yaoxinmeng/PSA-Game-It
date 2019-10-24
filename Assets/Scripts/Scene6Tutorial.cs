using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6Tutorial : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //checks if tutorial has been completed previously
        if (PlayerPrefs.GetInt("Tutorial 6") == 1)
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
                PlayerPrefs.SetInt("Tutorial 6", 1);
            }
        }

        if (GuiController.canDismiss)
            transform.GetChild(1).gameObject.SetActive(true);
        else
            transform.GetChild(1).gameObject.SetActive(false);
    }
}
