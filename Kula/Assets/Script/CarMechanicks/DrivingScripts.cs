using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScripts : MonoBehaviour
{
    public Wheel[] wheels;

    public float torque = 500;
    public float maxSteerAngle = 30;
    public float masBrakeTorque = 500;
    public float Maxspeed = 200;//km/h

    public Rigidbody rb;
    public float currentSpeed;


    public void Drive(float accel,float brake ,float streer) {
        accel = Mathf.Clamp(accel, -1, 1);
        brake = Mathf.Clamp(brake, 0, 1) * masBrakeTorque;
        streer = Mathf.Clamp(streer, -1, 1) * maxSteerAngle;

        float appliedTorque = 0;
        currentSpeed = rb.velocity.magnitude * 3.6f; //m/s -->Km/h

        if(currentSpeed < Maxspeed)
        {
            appliedTorque = accel * torque;
        }

        foreach (Wheel wheel in wheels)
        {
            wheel.wh.motorTorque = appliedTorque;
            if (wheel.FrontWheel)
            {
                wheel.wh.steerAngle = streer;
            }
            if (!wheel.FrontWheel)
            {

                wheel.wh.brakeTorque = brake;
               
            }
        }
    }
        
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float streer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");
        if (!RaceController.racePanding)
        {
            accel = 0;
        }
        Drive(accel, brake, streer);
    }
}
