using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    public List<GameObject> _go;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CC>())
        {
            Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CC>())
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        foreach (var item in _go)
        {
            Destroy(item.gameObject);
        }
    }
}
