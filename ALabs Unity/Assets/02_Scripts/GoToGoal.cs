using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoToGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> goals = new List<Transform>();
    public float speed = 5f;
    private int currentGoalIndex = 0;
    public bool play = false;


    void Start()
    {
        if(goals.Count > 0)
        {
            transform.position = goals.ElementAt(0).position;
        }
        else
        {
            Debug.Log("No States Added Yet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(play)
        {
            GoToNextGoal(); 
        }
        else
        {
            transform.position = goals.ElementAt(0).position;
        }
    }

    void GoToNextGoal()
    {
        if(currentGoalIndex < goals.Count)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, goals.ElementAt(currentGoalIndex).position, step);
            if(transform.position == goals.ElementAt(currentGoalIndex).position )
            {
                currentGoalIndex++;
            }
        }

        if(currentGoalIndex >= goals.Count)
        {
            play = false;
            currentGoalIndex = 0;
            Destroy(this.gameObject, 2);
        }
    }
}
