using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    public float mySpeed = 10f;

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
        gameObject.transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);
    }
}
