using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

}
