using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // allows the levels loaded to be inputted
    public string newGameScene; // name of desired next scene
    //string titleScene = "Title"; // name of title scene
    //string optionsScene = "Settings"; // name of options scene
    //string infoScene = "Info"; // name of credits scene

    public GameObject TitlePanel;
    public GameObject InfoPanel;

    public void NextScene()
    {
        // loads inputted level, starting at one for new games
        SceneManager.LoadScene(newGameScene);
    }

    public void GoToMenu()
    {
        // loads menu
        //SceneManager.LoadScene(titleScene);
        TitlePanel.SetActive(true);
        InfoPanel.SetActive(false);
    }

    public void GoToInfo()
    {
        // loads options
        //SceneManager.LoadScene(optionsScene);
        TitlePanel.SetActive(false);
        InfoPanel.SetActive(true);
    }

    /*public void GoToInfo()
    {
        // loads credits
        SceneManager.LoadScene(infoScene);
    }*/


    public void QuitGame()
    {
        // quits game
        Application.Quit();
    }
}