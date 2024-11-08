using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Scene to begin game
    public string goToScene = "Scene1";
    public string titleScene = "Title";
    public void StartGame()
    {
        SceneManager.LoadScene(goToScene);
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene(titleScene);
    }
    public void QuitGame()
    {
        #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}