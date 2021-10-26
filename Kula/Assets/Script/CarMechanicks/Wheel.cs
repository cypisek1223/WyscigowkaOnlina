using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public WheelCollider wh;
    public Transform wheel_modle;
    public bool FrontWheel;
   

    

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        Quaternion rot;

        wh.GetWorldPose(out pos, out rot);
        wheel_modle.position = pos;
        wheel_modle.rotation = rot;

    }
}
