using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool GameIsPause = false;

    public GameObject pauseUI;

    public GameObject crossHairUI;

    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                PauseEnabled();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        crossHairUI.SetActive(true);
        GameIsPause = false;
        Time.timeScale = 1f;
    }

    void PauseEnabled()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
        crossHairUI.SetActive(false);
        GameIsPause = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
