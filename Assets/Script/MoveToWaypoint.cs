using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    public GameObject waypoint;

    bool isGoing;

    private void Update()
    {
        if (isGoing && transform.position.y < waypoint.transform.position.y)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }

    public void TurnOn()
    {
        isGoing = true;
    }
}
