using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSuportScript : MonoBehaviour
{
    Rigidbody rb;
    float lastTimeOK;
     // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y > 0.5f || rb.velocity.magnitude > 1)
        {
            lastTimeOK = Time.deltaTime;

        }
        if (Time.deltaTime > lastTimeOK + 3)
        {
            TurnCarBack();
        }
    }

    private void TurnCarBack()
    {
        transform.position += Vector3.up;
        transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
