using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = 1f;
    public float xOffset = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x + xOffset, target.position.y + yOffset,  - 10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
