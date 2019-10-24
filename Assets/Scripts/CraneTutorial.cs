using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraneTutorial : MonoBehaviour {
    List<GameObject> list = new List<GameObject>();
    private GameObject[] tutorialList;

    private float accumtime = 0;
    public static int n;

    public float displayTime;

    // Use this for initialization
    void Start () {
        foreach(Transform child in transform)
        {
            if (child != transform)
                list.Add(child.gameObject);
        }
        tutorialList = list.ToArray();
        for (int x = 0; x < transform.childCount; x++)
        {
            if (x == 0)
                tutorialList[x].SetActive(true);
            else
                tutorialList[x].SetActive(false);
        }
        n = 0;
    }

    // Update is called once per frame
    void Update () {
        if (n == 0)
            tutorialList[n].SetActive(true);
        if (n < transform.childCount)
        {
            accumtime += Time.deltaTime;
            if (accumtime > displayTime)
            {
                tutorialList[n].SetActive(false);
                accumtime = 0;
                n++;
                if (n < transform.childCount)
                    tutorialList[n].SetActive(true);
            }
        }
	}
}
