using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    
    public GameObject objectsToActivate;
    public GameObject objectsToDeactivate;
    public GameObject Main;
    public GameObject Options;
    public GameObject Quit;
    public GameObject Back;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (Input.GetButtonDown("Start"))
        {
            if (gameIsPaused)
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
        objectsToDeactivate.SetActive(true);
        objectsToActivate.SetActive(false);
        Back.SetActive(false);
        Quit.SetActive(false);
        Options.SetActive(false);
        Main.SetActive(true);
        Time.timeScale = 1f;
        fps.enabled = true;
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        objectsToDeactivate.SetActive(false);
        objectsToActivate.SetActive(true);
        Time.timeScale = 0f;
        fps.enabled = false;
        gameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
   
}
