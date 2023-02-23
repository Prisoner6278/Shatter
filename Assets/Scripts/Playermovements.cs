using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovements : MonoBehaviour
{
    //For LimitRot()
    public float maxYRot = 20f;
    public float minYRot = -20f;
    private Transform localTrans;

    //For WASDMove()
    public float speed = 0.01f;
    //public float heavySpeed = 0.1f;

    //For MoveForward()
    private float mySpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        localTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        WASDMove();
        LimitRot();
    }

    void MoveForward()
    {
        gameObject.transform.Translate(Vector3.forward * mySpeed * Time.deltaTime, Space.World);
    }

    void LimitRot()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;
        playerEulerAngles.y = (playerEulerAngles.y > 180) ? playerEulerAngles.y - 360 : playerEulerAngles.y;
        playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, minYRot, maxYRot);
        localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    }

    void WASDMove()
    {
        float xDrection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDrection, zDirection, 0.0f);

        transform.position += moveDirection * speed;
        if (Time.timeScale == 0)
        {
            speed = 0f;
        }else if(Time.timeScale > 0)
        {
            speed = 0.01f;
        }
    }
}
