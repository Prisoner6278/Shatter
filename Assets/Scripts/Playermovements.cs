using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovements : MonoBehaviour
{
    public float speed = 10f;
    private float mySpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
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
        //turn.x += Input.GetAxis("Mouse X");
        //turn.y += Input.GetAxis("Mouse Y");
        //transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    void MoveForward()
    {
        gameObject.transform.Translate(Vector3.forward * mySpeed * Time.deltaTime, Space.World);
    }
}
