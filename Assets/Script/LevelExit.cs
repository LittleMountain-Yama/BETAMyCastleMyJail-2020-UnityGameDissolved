using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int number;
    public float timeWait;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CC>())
        {         
            StartCoroutine(LoadScene());
        }
    }  

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(timeWait);
        SceneManager.LoadScene(number);
        StartCoroutine(LoadScene());
    }
}
