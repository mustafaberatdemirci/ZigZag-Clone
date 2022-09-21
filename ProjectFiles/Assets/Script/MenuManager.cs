using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool gameispaused = false;
    public static bool startgame = false;
    public GameObject uiMenu;
    public GameObject exitbutton;
    [SerializeField]  GameObject exitdestroy;
    public GameObject rightframe;
    public bool buttonEnabled=true;
    //public Text buttonText;
    //public Image buttonIcon;

    // Update is called once per frame

     void Start()
     {
         //gameObject.GetComponent<Button>().onClick.AddListener(Resume);
         //exitbutton.SetActive(false);
     }

    public void ButtonClicked()
    {
        //Debug.Log("buton clicke girdi");
        //buttonEnabled = !buttonEnabled;
        //rightframe.SetActive(!buttonEnabled);
        if (buttonEnabled==true)
        {
            //Resume();
            /*
            if (startgame)
            {
                Resume();
            }
            else
            {
                Exit();
            }
            //*/
        }
        else
        {
            Exit();
        }
    }

    public void destroyobject()
    {
        Destroy(exitdestroy.GetComponent<Button>());
    }

    public void Resume()
    {
        //Debug.Log("resumeye girdi");
        //uiMenu.SetActive(true);
        //rightframe.SetActive(true);
        //exitbutton.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }
    
    public void Exit()
    {
        //uiMenu.SetActive(true);
        //rightframe.SetActive(true);
        //Time.timeScale = 0f;
        //gameispaused = true;
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
