using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public string triggerText, objetiveText;
    public float time;
    bool triggered;
    public bool changeObjective;
    DialogChanger _dc;

    private void Awake()
    {
        _dc = FindObjectOfType<DialogChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CC>() && !triggered)
        {
            triggered = true;
            _dc.TurnOn(triggerText);             
            StartCoroutine(_dc.OffTime(time, this));

            if (changeObjective)
            {
                ChangeObjetive();
            }
        }
    }

    void ChangeObjetive()
    {
        _dc.ChangeObjetive(objetiveText);
    }

    public void SelfDestruct()
    {
        Destroy(this);
    }
}
