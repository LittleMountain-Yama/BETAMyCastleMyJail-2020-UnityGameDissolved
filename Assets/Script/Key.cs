using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    //JumpBoost _jb;
    public GameObject text;

    private void Awake()
    {
       // _jb = FindObjectOfType<JumpBoost>();
    }   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
           // _jb.isOn = true;
            Message();
        }
    }

    void Message()
    {
        text.SetActive(true);
        StartCoroutine(StopText());
    }

    IEnumerator StopText()
    {
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
        StopCoroutine(StopText());
    }
}
