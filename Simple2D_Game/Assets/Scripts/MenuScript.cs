using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private bool pause;
    public GameObject Menu;
    void Start()
    {
        Time.timeScale = 1;
        if (Menu != null)
        {
            Menu.SetActive(false);
            pause = Menu.activeInHierarchy;
        }
    }

    void Update()
    {
        if (Menu != null) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(!pause);
                pause = Menu.activeInHierarchy;
                Pause();
            }
        }
            
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
