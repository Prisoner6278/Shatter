using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    AudioSource glassBreak; 

    public float health = 50f;

    // Start is called before the first frame update
    void Start()
    {
        glassBreak = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            glassBreak.Play();
            Die();
            Debug.Log("glass broken");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.StopMusic("Theme");
            AudioManager.Instance.StopSFXLoop("SkyDiving");
            SceneManager.LoadScene("GameOverScene");
        }
    }

}
