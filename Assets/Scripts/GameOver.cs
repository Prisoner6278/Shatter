using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public AudioSource GameOverSound;

    //public AudioSource ClickSound;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //GameOverSound.Play();
    }

    public void Retry()
    {
        //ClickSound.Play();
        SceneManager.LoadScene("Shatter");
    }

    public void Quit()
    {
        //ClickSound.Play();
        Debug.Log("QUIT");
        Application.Quit();
    }
}
