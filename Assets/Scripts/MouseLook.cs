using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //For mouse();
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    public Camera cam1;
    public Camera cam2;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    public bool InSlowMo;

    public float timeScaleNum;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouse();

        if (InSlowMo == true)
        {
            ReStoreTime();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            DoSlowmotion();
            cam1.enabled = false;
            cam2.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
    }

    void mouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        InSlowMo = true;
    }

    public void ReStoreTime()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1.0f)
        {
            InSlowMo = false;
        }
    }
}
