using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Controller : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public GameObject controlUI;

    // Update is called once per frame

    void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    
    public void LoadMenu()
    {
        SceneManager.LoadScene("IntroScreen");
        Time.timeScale = 1f;
    }

    public void LoadControls()
    {
        Debug.Log("Show Controls");
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
