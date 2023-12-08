using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lr;
    [SerializeField] private List<Transform> points;


    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        SetUpLine(points);
    }

    public void SetUpLine(List<Transform> points)
    {
        lr.positionCount = points.Count;
        this.points = points;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < points.Count; i++)
        {
            if(points.ElementAt(i) != null)
            {
                lr.SetPosition(i, points.ElementAt(i).position);
            }
            else
            {
                SetUpLine(points);
            }
        }
    }
}
