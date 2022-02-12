using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public GameObject aboutControlUI;
    public GameObject aboutCreditUI;


    void Start()
    {
        aboutControlUI.SetActive(false);
        aboutCreditUI.SetActive(false);
    }

    public void LoadAboutControl()
    {
        Debug.Log("Loading Controls");
        aboutCreditUI.SetActive(false);
        aboutControlUI.SetActive(true);
    }

    public void LoadAboutCredit()
    {
        Debug.Log("Loading Credits");
        aboutControlUI.SetActive(false);
        aboutCreditUI.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
