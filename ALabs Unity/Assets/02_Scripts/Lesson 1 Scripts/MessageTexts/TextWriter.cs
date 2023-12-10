using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    // audio 

    public AudioSource tvoutputaudio;

    private TextWriterSingle temp;

    private void Awake()
    {
        instance = this;   
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriter_Static(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }
    public void AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        temp = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, true);
        textWriterSingleList.Add(temp);
        tvoutputaudio.Play();
    }

    private void Update()
    {
        if(temp != null && temp.isDoneOutput == false)
        {
            tvoutputaudio.Stop();
            
        }
        // Debug.Log(textWriterSingleList.Count); 
        for(int i =0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].textUpdate();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
}




