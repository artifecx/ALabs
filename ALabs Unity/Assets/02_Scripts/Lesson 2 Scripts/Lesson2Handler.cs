using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2Handler : MonoBehaviour
{
    public GameObject mainpage;
    public GameObject[] page;
    public GameObject[] alphabetTopics;
    public GameObject[] stringTopics;
    public GameObject[] languagesTopics;

    int currAlphaTopic = 0;
    int currStringTopic = 0;
    int currLanguagesTopic = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in page)
        {
            item.SetActive(false);
        }    
    }

    public void PageNext(int num)
    {
        mainpage.SetActive(false);
        for (int i = 0; i < page.Length; i++)
        {
            if(i==num)
                page[i].SetActive(true);
            else
            {
                page[i].SetActive(false);
            }
        }
    }

    /*public void PageBack()
    {
        if(currAlphaTopic > 0)
        {
            for (int i = 0; i < alphabetTopics.Length; i++)
            {
                if (i == currAlphaTopic)
                    alphabetTopics[i].SetActive(true);
                else
                {
                    alphabetTopics[i].SetActive(false);
                }
            }
            currAlphaTopic--;
        }
        else
        {
            maincanvas.SetActive(true);
            canvas[0].SetActive(false);
        }
    }*/
}


