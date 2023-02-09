using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool GameIsPause = false;

    public GameObject pauseUI;

    public GameObject crossHairUI;

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
        Time.timeScale = 1f;
        GameIsPause = false;
        crossHairUI.SetActive(true);

    }

    void PauseEnabled()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        crossHairUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
