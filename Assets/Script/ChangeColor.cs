using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Light lightcolor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CC>())
        {
            lightcolor.color = new Color(1, 0, 1);
        }
    }
}
