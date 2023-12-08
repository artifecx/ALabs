//using PlayFab.PfEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

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

        if(moveRight && isMoving)
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

