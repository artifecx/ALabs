using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Msg_Assistant : MonoBehaviour
{
    [SerializeField] private TMP_Text[] messageText;
    [SerializeField] private TextWriter textWriter;
    [SerializeField] private float msgspeed = 0.05f;

    private string[] messagesArray = 
        {"Welcome to ALabs!\n\nA place where you will start your journey in learning all about Automata Theory!",

         "Before we jump right into the game, let's talk about what Automata Theory is all about.",

         "Imagine you are dealing with building blocks for computers and programming...\n\n" +
         "Automata Theory is like exploring the rules and structures that controls these building blocks!",

         "In this case, lets explore how Automata theory works in a Factory Setting!",

         "Let's breakdown how this factory setting in three different parts:\r\n\r\n1. State machines\r\n2. Transitions\r\n2. Finite Automation",

         "State Machines:\r\n\r\nIn the context of automata theory, a \"state\" refers to a condition or situation in which a system or process can exist at a given point in time. \r\n",

         "This is an example of a state. Normally, it does not look like this but for visualization purposes, " +
            "it accompanies a condition wherein it accepts or unaccepts a product depending on what the state asks.",

         "Transitions:\r\nThese refer to the changes in the state of a system based on certain events, inputs, or conditions. " +
         "They define how a system moves from one state to another.",
         
         "As for now, these \'Conveyer Belts\' will serve as our best example for transitioning products.",

         "A Finite Automaton is a theoretical model used in automata theory to represent systems with a finite number of states, transitions between states, and an input.",

         "In Layman's terms, a Finite Automaton is a machine composed of both transitions and states combined! As showcased here, both states accepted you as their input which fulfilled their conditions!",

         "Now that you got the basics, let's dive right into the game. \r\n\r\nPress this button if you are ready.",
    };          
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Message(string message, TMP_Text text)
    {
        textWriter.AddWriter(text, message, msgspeed, true);

    }

    public void MessageChoice(int choice)
    {
        if(choice < messageText.Length)
        {
            Message(messagesArray[choice], messageText[choice]);
        } else
        {
            return;
        }
        
    }
}
