using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GoToState : MonoBehaviour
{
    public Transform start;
    public Transform[] goalStates;
    public float speed = 5f;
    private void Start()
    {
       this.transform.position = start.position;
    }
    private void Update()
    {
        for(int i = 0; i < goalStates.Length; i++)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, goalStates[0].position, speed * Time.deltaTime);
        }
    }
}
