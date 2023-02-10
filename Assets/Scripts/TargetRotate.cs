using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    public float mySpeed = 1f;
    public float rotSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    void MoveForward()
    {
        gameObject.transform.Translate(Vector3.forward * mySpeed * Time.deltaTime, Space.World);
        gameObject.transform.Rotate(1, 1, 0);
    }
}
