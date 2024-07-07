using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int sceneNumber;
    public GameObject MenuGeneral, HowTo;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void HowToPlay()
    {
        if (HowTo.activeSelf == true)
        {
            HowTo.SetActive(false);
            MenuGeneral.SetActive(true);
        }
        else
        {
            HowTo.SetActive(true);
            MenuGeneral.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
