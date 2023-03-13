using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool GameIsPause = false;

    public GameObject pauseUI;

    public GameObject crossHairUI;

    public MouseLook look;

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
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        crossHairUI.SetActive(true);
        GameIsPause = false;
    }

    void PauseEnabled()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
        crossHairUI.SetActive(false);
        GameIsPause = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
