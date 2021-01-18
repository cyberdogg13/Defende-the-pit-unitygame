using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 90f, 0f);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, -90f, 0f);

        }

    }
}
