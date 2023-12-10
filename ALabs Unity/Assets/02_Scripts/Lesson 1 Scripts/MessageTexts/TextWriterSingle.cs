using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWriterSingle
{
    [SerializeField] private TMP_Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;


    public bool isDoneOutput;

    // audio

    

    public TextWriterSingle(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool isDoneOutput)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
        this.isDoneOutput = isDoneOutput;
        
    }

    // returns true when complete
    public bool textUpdate()
    {
            timer -= Time.deltaTime; 
            while (timer <= 0f)
            {
                
                // Display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = uiText.text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }

                if (characterIndex >= textToWrite.Length)
                {
                //Entire string displayed
                isDoneOutput = false;
                    return true;
                }
            }
        return false;
    }
}
