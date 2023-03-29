using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // allows the levels loaded to be inputted
    public string newGameScene; // name of desired next scene
    public string tutorialScene;

    public GameObject TitlePanel;
    public GameObject StartPanel;
    public GameObject InfoPanel;

    public void NextScene()
    {
        // loads inputted level, starting at one for new games
        SceneManager.LoadScene(newGameScene);
    }

    public void TutScene()
    {
        // loads inputted level, starting at one for new games
        SceneManager.LoadScene(tutorialScene);
    }

    public void GoToMenu()
    {
        // loads menu
        //SceneManager.LoadScene(titleScene);
        TitlePanel.SetActive(true);
        InfoPanel.SetActive(false);
        StartPanel.SetActive(false);
    }

    public void GoToInfo()
    {
        // loads options
        //SceneManager.LoadScene(optionsScene);
        TitlePanel.SetActive(false);
        InfoPanel.SetActive(true);
    }

    public void GoToStart()
    {
        // loads options
        //SceneManager.LoadScene(optionsScene);
        TitlePanel.SetActive(false);
        StartPanel.SetActive(true);
    }


    public void QuitGame()
    {
        // quits game
        Application.Quit();
    }
}