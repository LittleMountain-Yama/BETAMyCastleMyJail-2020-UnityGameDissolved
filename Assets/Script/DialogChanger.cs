using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChanger : MonoBehaviour
{
    public Text textToChange, objective;
    public GameObject box;

    private void Awake()
    {
        textToChange.text = "";
        objective.text = "";
        objective.gameObject.SetActive(false);
        box.SetActive(false);
    }

    public void TurnOn(string text)
    {
        box.SetActive(true);
        textToChange.text = text;
    }

    public void TurnOff()
    {
        textToChange.text = "";
        box.SetActive(false);
    }

    public void ChangeObjetive(string text)
    {
        objective.gameObject.SetActive(true);
        objective.text = text;
    }

    public IEnumerator OffTime(float time, DialogTrigger trigger)
    {
        yield return new WaitForSeconds(time);
        TurnOff();
        trigger.SelfDestruct();
        StopCoroutine(OffTime(time, trigger));
    }
}
