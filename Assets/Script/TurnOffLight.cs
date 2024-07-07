using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{
    public Light lightcolor, lightTwo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CC>())
        {
            lightcolor.gameObject.SetActive(false);
            lightTwo.gameObject.SetActive(false);
        }
    }
}
