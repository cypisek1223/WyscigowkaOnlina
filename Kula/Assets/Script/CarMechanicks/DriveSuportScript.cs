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
        //print(transform.up.y);
        if (transform.up.y > 0.5f || rb.velocity.magnitude > 1)
        {
            lastTimeOK = Time.time;

        }
        if (Time.time > lastTimeOK + 3)
        {
            TurnCarBack();
        }
    }

    private void TurnCarBack()
    {
        print("Turn back attempt");
        transform.position += Vector3.up;
        transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
