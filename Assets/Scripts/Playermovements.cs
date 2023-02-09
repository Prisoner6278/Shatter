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
    public float speed = 10f;

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
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
