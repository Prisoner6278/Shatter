using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 60f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            AudioManager.Instance.StopMusic("Theme");
            AudioManager.Instance.StopSFXLoop("SkyDiving");
            SceneManager.LoadScene("Shatter_Win");
        }

    }
}
