using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatePlacer : MonoBehaviour
{
    // Start is called before the first frame update
    public int num = 2;
    [SerializeField] private GameObject[] states;
    [SerializeField] private GameObject data;
    [SerializeField] private LineController linecontrol;
    
    private List<GameObject> gstates = new List<GameObject>();
    public List<Transform> goals = new List<Transform>();
    private int[] sAvailable = { 0, 0, 0, 0 };
    private int choice = 0;

    GameObject hitObject;
    int counter = 0;

    private void Start()
    {
        linecontrol.GetComponent<LineRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && choice > 0) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider != null)
            {
                hitObject = hit.collider.gameObject;
            }
            PlaceState();
        }
    }

    public void PlaceState()
    {
        if (hitObject.name.Contains("Hexagon") && hitObject.GetComponent<SlotChecker>().GetIsOpen() == true)
        {
            if (sAvailable[choice - 1] == 0)
            {
                GameObject newState = Instantiate(states[choice - 1], hitObject.transform.position, Quaternion.identity);


                newState.transform.position = new Vector2(newState.transform.position.x, newState.transform.position.y);
                gstates.Add(newState);
                goals.Add(newState.transform);
                sAvailable[choice - 1]++;
            }
            else
            {
                for (int i = 0; i < gstates.Count; i++)
                {
                    int num = choice - 1;
                    if (gstates.ElementAt(i).name.Contains(num.ToString()))
                    {
                        gstates.ElementAt(i).transform.position = hitObject.transform.position;

                        gstates.ElementAt(i).transform.position = new Vector2(gstates.ElementAt(i).transform.position.x, gstates.ElementAt(i).transform.position.y);
                    }
                }
            }
            choice = 0;
        }
    }

    public void PickState(int num)
    {
        choice = num;
    }

    public void MoveData()
    {
        if(goals.Count > 0)
        {
            StartCoroutine(SpawnData());
            linecontrol.GetComponent<LineRenderer>().enabled = true;
            linecontrol.SetUpLine(goals);
        }
    }

    IEnumerator SpawnData()
    {
        for(int i = 0;i < num; i++)
        {
            GameObject newData = Instantiate(data, goals.ElementAt(1).transform.position, Quaternion.identity);
            newData.GetComponent<GoToGoal>().goals = goals;
            newData.GetComponent<GoToGoal>().play = true;

            float hue = Mathf.Lerp(0f, 1f, (float)i / num);
            Color newColor = Color.HSVToRGB(hue, 1f, 1f);

            newData.GetComponent<SpriteRenderer>().color = newColor;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
