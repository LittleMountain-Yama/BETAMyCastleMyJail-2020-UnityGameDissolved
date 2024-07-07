using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointActivator : MonoBehaviour
{
    public List<MoveToWaypoint> list = new List<MoveToWaypoint>();

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CC>())
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].TurnOn();
            }           
        }
    }
}
