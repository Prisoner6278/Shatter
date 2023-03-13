using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool GameIsPause = false;

    public GameObject pauseUI;

    public GameObject crossHairUI;

    MouseLook look;

    // Start is called before the first frame update
    void Start()
    {
        look = GameObject.Find("CameraFront").GetComponent<MouseLook>();
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
        if(look.currentTimeScale < 0)
        {
            Time.timeScale = look.currentTimeScale;
            look.InSlowMo = true;
        }
        Time.timeScale = 1f;
        AudioManager.Instance.ResumeMusic("Theme");
        AudioManager.Instance.LoopSFX("SkyDiving");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        crossHairUI.SetActive(true);
        GameIsPause = false;
    }

    void PauseEnabled()
    {
        if (Time.timeScale < 0)
        {
            look.currentTimeScale = Time.timeScale;
        }
        look.InSlowMo = false;
        Time.timeScale = 0f;
        AudioManager.Instance.PauseMusic("Theme");
        AudioManager.Instance.StopSFXLoop("SkyDiving");
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
