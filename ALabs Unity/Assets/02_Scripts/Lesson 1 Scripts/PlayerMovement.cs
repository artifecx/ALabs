//using PlayFab.PfEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;

    private int currentPoint = 0;
    private bool isMoving = false;
    public float moveSpeed = 5f;
    public float stopDistance = 0f;
    int firstright = 0;

    // checker

    public Msg_Assistant msgassist;

    // Audio 
    public AudioSource conveyeraudio;
    // public AudioSource tvoutputaudio;


    public Animator[] animator;

    void Update()
    {
        HandleInput();
        MoveToTargetPosition();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            SetMovementVariables(true, false);
            conveyeraudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            SetMovementVariables(false, true);
            conveyeraudio.Play();
        }
    }

    void ActivateCheckMark()
    {
        // Check if the CheckMark exists and is not already active
        if (currentPoint == 11 && checkmark1 != null && !checkmark1.activeSelf)
        {
            checkmark1.SetActive(true);
        }
        else if (currentPoint == 12 && checkmark2 != null && !checkmark2.activeSelf)
        {
            checkmark2.SetActive(true);
        }
    }

    void SetMovementVariables(bool moveRight, bool moveLeft)
    {
        isMoving = true;
        if (moveRight && firstright == 0)
        {
            currentPoint = 0;
            firstright++;
            
        }
        else if (moveRight)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
        }
        else if (moveLeft && currentPoint > 0)
        {
            currentPoint--;
        }

        if (moveRight && isMoving)
        {
            foreach (Animator anim in animator)
            {
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
            }
        }

        if (moveLeft && isMoving)
        {
            foreach (Animator anim in animator)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
            }
        }
    }

    private float arrivalTime;
    // CheckMarks
    [SerializeField] private GameObject checkmark1;
    [SerializeField] private GameObject checkmark2;

    void MoveToTargetPosition()
    {
        if (isMoving)
        {
            Vector3 direction = waypoints[currentPoint].position - transform.position;

            if (direction.magnitude > stopDistance)
            {
                direction.Normalize();
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                Debug.Log("Current waypoint: " + currentPoint);
                msgassist.MessageChoice(currentPoint);
                isMoving = false;
                conveyeraudio.Stop();
                foreach (Animator anim in animator)
                {
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                }
            }
        }
    }

    

}


