using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpTo : MonoBehaviour
{
    public GameObject location;
    CC _cc;

    private void Awake()
    {
        _cc = FindObjectOfType<CC>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CC>())
        {
            _cc.transform.position = location.transform.position;
            collision.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
