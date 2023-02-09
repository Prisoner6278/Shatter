using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        this.transform.position = Input.mousePosition;
    }
}
